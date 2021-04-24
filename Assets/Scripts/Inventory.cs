using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    public GameObject weapons;
    public GameObject player;
    public GameObject pistol;
    public GameObject shootGun;
    public GameObject akm;


    private float pickUpRange = 3.0f;
    private bool isHide = false;
    public static bool isPistolInInventory { get; set; }
    public static bool isShootGunInInventory { get; set; }
    public static bool isAkmGunInInventory { get; set; }

    void Start()
    {
        isPistolInInventory = false;
        isShootGunInInventory = false;
        isAkmGunInInventory = false;

        pistol.SetActive(false);
        shootGun.SetActive(false);
        akm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            isHide = !isHide;
            cat.SetActive(isHide);
        }
        GetDistance();
    }
    private void GetDistance()
    {
        int childrenCount = weapons.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject child = weapons.transform.GetChild(i).gameObject;
            Vector3 distanceToPlayer = player.transform.position - child.transform.position;
            if (distanceToPlayer.magnitude <= pickUpRange)
            {
                //if (child.name == akm.name)
                //{
                //    akm.SetActive(true);
                //    isAkmGunInInventory = true;
                //}
                if (child.name == pistol.name)
                {
                    pistol.SetActive(true);
                    isPistolInInventory = true;
                }
                if (child.name == shootGun.name)
                {
                    shootGun.SetActive(true);
                    isShootGunInInventory = true;
                }

                child.SetActive(false);
            }

        }
    }
}
