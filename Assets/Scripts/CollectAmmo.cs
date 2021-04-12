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
            if(hit.transform.name == "box_ammo")
            {
                pickUpText.SetActive(true);
                if(Input.GetKeyDown("e"))
                {
                    AKM.currentAmmo = 30;
                    Pistol.currentAmmo = 12;
                    Shotgun.currentAmmo = 8;
                }
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }
    }

}
