using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AKM : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    private int magazineAmount = 30;

    public static int maxAmmoAmount = 90;
    public static int currentAmmo;
    public float reloadTime = 1f;
    private bool isRealoading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzeFire;

    private float nextTimeToFire = 0f;

    public Text AmmoInfoText = null;

    void Start()
    {

        if (maxAmmoAmount >= magazineAmount)
        {
            currentAmmo = maxAmmoAmount / 3;
        }
        else
        {
            currentAmmo = maxAmmoAmount;
        }
    }


    void Update()
    {
        AmmoInfoText.text = $"{currentAmmo}/{maxAmmoAmount}";

        if (isRealoading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            if (currentAmmo > 0)
            {
                Shoot();
            }
        }
    }

    IEnumerator Reload()
    {
        isRealoading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        if (maxAmmoAmount >= magazineAmount)
        {
            currentAmmo = magazineAmount;
            maxAmmoAmount -= magazineAmount;
        }
        else
        {
            currentAmmo = maxAmmoAmount;
        }
        isRealoading = false;
    }

    void Shoot()
    {
        muzzeFire.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
