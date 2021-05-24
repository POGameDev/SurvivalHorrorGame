using UnityEngine;

[System.Serializable]
public class DataToSave : MonoBehaviour
{
    public CharacterController controller;
    public GameObject NormalDoor;
    public GameObject RustyDoor;

    public GameObject gasCan1;
    public GameObject gasCan2;
    public GameObject gasCan3;


    public int health;//
    public float[] playerPosition;//
    public float str;//

    public bool isShotgunPicked;//
    public bool isPistolPicked;//

    public int shotgunAmmo;//
    public int akmAmmo;//
    public int pistolAmmo;//

    public bool isNormalKeyPicked;//
    public bool isRustyKeyPicked;//

    public bool isFlashLightOn;//

    //public Vector3 zombie1Position;
    //public Vector3 zombie2Position;
    //public Vector3 zombie3Position;
    //public Vector3 zombie4Position;
    //public Vector3 zombie5Position;
    //public Vector3 zombie6Position;
    //public Vector3 zombie7Position;
    //public Vector3 zombie8Position;
    //public Vector3 zombie9Position;
    //public Vector3 zombie10Position;
    //public Vector3 zombie11Position;

    public int ZombieHealth; // - leater 

    public bool isNormalKeyDoorOpen;//
    public bool isRustyKeyDoorOpen;//

    public bool isGasCan1Picked;//
    public bool isGasCan2Picked;//
    public bool isGasCan3Picked;//

    public DataToSave(/*, KeyHolder keyHolder*/)
    {
        health = UserInterface.Health;

        //playerPosition = new float[3];
        //playerPosition[0] = controller.transform.position.x;
        //playerPosition[1] = controller.transform.position.y;
        //playerPosition[2] = controller.transform.position.z;

        str = Strength.Str;

        shotgunAmmo = Shotgun.currentAmmo;
        pistolAmmo = Pistol.currentAmmo;
        akmAmmo = AKM.currentAmmo;

        isFlashLightOn = FlashLight.LightActive;

        //isNormalKeyPicked = keyHolder.ContainsKey(Key.KeyType.NormalKey);
        //isRustyKeyPicked = keyHolder.ContainsKey(Key.KeyType.Rustykey);

        isShotgunPicked = Inventory.isShootGunInInventory;
        isPistolPicked = Inventory.isPistolInInventory;

        //isNormalKeyDoorOpen = NormalDoor.activeSelf;
        //isRustyKeyDoorOpen = RustyDoor.activeSelf;

        //isGasCan1Picked = gasCan1.activeSelf;
        //isGasCan2Picked = gasCan2.activeSelf;
        //isGasCan3Picked = gasCan3.activeSelf;
    }
}
