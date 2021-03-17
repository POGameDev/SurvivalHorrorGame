using UnityEngine;


public class AKM : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;
    public ParticleSystem muzzeFire;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzeFire.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        
    }
}
