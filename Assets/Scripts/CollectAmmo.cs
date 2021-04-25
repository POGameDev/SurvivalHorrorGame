using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera fpsCamera;
    public GameObject pickUpText;
    private readonly float pickUpRange = 4.0f;

    void Start()
    {
        pickUpText.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, pickUpRange))
        {
            if (hit.transform.name == "box_ammo")
            {
                pickUpText.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    if (AKM.currentAmmo < 30 || AKM.maxAmmoAmount < 90)
                    {
                        AKM.currentAmmo = 30;
                        AKM.maxAmmoAmount = 90;
                    }

                    if (Pistol.currentAmmo < 12 || Pistol.maxAmmoAmount < 48)
                    {
                        Pistol.currentAmmo = 12;
                        Pistol.maxAmmoAmount = 48;
                    }

                    if (Shotgun.currentAmmo < 8 || Shotgun.maxAmmoAmount < 32)
                    {
                        Shotgun.currentAmmo = 8;
                        Shotgun.maxAmmoAmount = 32;
                    }

                }
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }
    }

}
