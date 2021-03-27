using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public static int selectedWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
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
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(i == selectedWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
