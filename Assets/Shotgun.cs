using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 50f;
    public float fireRate = 5f;

    public int maxAmmo = 8;
    public static int currentAmmo;
    public float reloadTime = 4f;
    private bool isRealoading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzeFire;

    private float nextTimeToFire = 1f;

    public Text AmmoInfoText = null;

    void Start()
    {
        currentAmmo = maxAmmo;
    }


    void Update()
    {
        AmmoInfoText.text = $"{currentAmmo}/{maxAmmo}";

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
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isRealoading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isRealoading = false;
    }

    void Shoot()
    {
        //muzzeFire.Play();

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