using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
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
            if (hit.transform.name == "box_med")
            {
                pickUpText.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    UserInterface.Health = 100;
                }
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }
    }
}
