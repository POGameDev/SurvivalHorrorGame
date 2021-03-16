using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    private bool isHide = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            isHide = !isHide;
            cat.SetActive(isHide);

            print("e key was pressed");
        }
    }
}
