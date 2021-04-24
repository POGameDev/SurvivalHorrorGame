using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public static int selectedWeaponIndex = 0;
    public GameObject weapons;
    public static List<GameObject> Guns { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //SelectWeapon();
        GameObject shootGun = weapons.transform.GetChild(0).gameObject;
        GameObject akm = weapons.transform.GetChild(1).gameObject;
        GameObject pistol = weapons.transform.GetChild(2).gameObject;
        shootGun.SetActive(false);
        akm.SetActive(true);
        pistol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeaponIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeaponIndex >= transform.childCount - 1)
            {
                selectedWeaponIndex = 0;
            }
            else
            {
                selectedWeaponIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeaponIndex <= 0)
            {
                selectedWeaponIndex = transform.childCount - 1;
            }
            else
            {
                selectedWeaponIndex--;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeaponIndex = 2;
        }

        if (previousSelectedWeapon != selectedWeaponIndex)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int childrenCount = weapons.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject weapon = weapons.transform.GetChild(i).gameObject;
            if (i == selectedWeaponIndex)
            {
                if (i == 1)
                {
                    weapon.SetActive(true);
                }

                if (Inventory.isPistolInInventory && i == 2)
                {
                    weapon.gameObject.SetActive(true);
                }
                else if (Inventory.isShootGunInInventory && i == 0)
                {
                    weapon.gameObject.SetActive(true);
                }
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }
}

