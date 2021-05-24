using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float runSpeed = 10f;

    //const float earthGravity = -9.81f;

    public float gravity = -29.43f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Move();

        Run();

        Jump();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("."))
        {
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@SAVE@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            SaveGameData();
        }
        if (Input.GetKeyDown(","))
        {
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@LOAD@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            LoadGameData();
        }
    }


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && Strength.HaveStr)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Strength.Str -= Strength.JumpLoseStr;
        }
    }

    private void Run()
    {
        if (Input.GetKey("left shift") && isGrounded && Strength.Str >= 1)
        {
            Strength.Str -= 1f;
        }
        if (Input.GetKeyDown("left shift") && isGrounded)
        {
            if (speed <= 12f)
            {
                speed += runSpeed;
            }
        }
        else if ((Input.GetKeyUp("left shift") || Strength.Str <= 1) && isGrounded)
        {
            if (speed > 12f)
            {
                speed -= runSpeed;
            }
        }
    }

    public void SaveGameData()
    {
        SaveData.Save();
        Debug.Log("Save Click");
    }

    public void LoadGameData()
    {
        Debug.Log("Load Click");
        DataToSave data = SaveData.LoadData();


        UserInterface.Health = data.health;

        //playerPosition = new float[3];
        //playerPosition[0] = controller.transform.position.x;
        //playerPosition[1] = controller.transform.position.y;
        //playerPosition[2] = controller.transform.position.z;

        Strength.Str = data.str;

        Shotgun.currentAmmo = data.shotgunAmmo;
        Pistol.currentAmmo = data.pistolAmmo;
        AKM.currentAmmo = data.akmAmmo;

        FlashLight.LightActive = data.isFlashLightOn;

        //isNormalKeyPicked = keyHolder.ContainsKey(Key.KeyType.NormalKey);
        //isRustyKeyPicked = keyHolder.ContainsKey(Key.KeyType.Rustykey);

        Inventory.isShootGunInInventory = data.isShotgunPicked;
        Inventory.isPistolInInventory = data.isPistolPicked;

        //isNormalKeyDoorOpen = NormalDoor.activeSelf;
        //isRustyKeyDoorOpen = RustyDoor.activeSelf;

        //isGasCan1Picked = gasCan1.activeSelf;
        //isGasCan2Picked = gasCan2.activeSelf;
        //isGasCan3Picked = gasCan3.activeSelf;
    }
}
