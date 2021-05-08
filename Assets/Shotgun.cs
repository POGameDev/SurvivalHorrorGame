using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 50f;
    public float fireRate = 15f;
    private int magazineAmount = 8;

    //public int maxAmmo = 8;
    public static int maxAmmoAmount = 32;
    public static int currentAmmo;
    public float reloadTime = 4f;
    private bool isRealoading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzeFire;

    private float nextTimeToFire = 1f;

    public Text AmmoInfoText = null;

    void Start()
    {
        if (maxAmmoAmount >= magazineAmount)
        {
            currentAmmo = maxAmmoAmount / 4;
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


        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
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
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
