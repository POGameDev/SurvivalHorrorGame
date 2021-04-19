using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject Light;
    private bool LightActive;
    void Start()
    {
        Light.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightActive = !LightActive;

            if (LightActive)
            {
                Light.SetActive(true);
            }

            if (!LightActive)
            {
                Light.SetActive(false);
            }
        }
    }
}
