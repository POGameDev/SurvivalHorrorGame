using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    public GameObject weapons;
    public GameObject player;
    public GameObject weapon1;
    public GameObject weapon2;


    private float pickUpRange = 3.0f;
    private bool isHide = false;

    void Start()
    {
        weapon1.SetActive(false);
        weapon2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            isHide = !isHide;
            cat.SetActive(isHide);
        }
        GetDistance();
    }
    private void GetDistance()
    {
        int childrenCount = weapons.transform.childCount;
        for(int i=0;i<childrenCount;i++)
        {
            GameObject child = weapons.transform.GetChild(i).gameObject;
            Vector3 distanceToPlayer = player.transform.position - child.transform.position;
            if(distanceToPlayer.magnitude <= pickUpRange)
            {
                
                if(child.name == weapon1.name)
                {
                    weapon1.SetActive(true);
                }
                if(child.name == weapon2.name) 
                {
                    weapon2.SetActive(true);
                }
                
                child.SetActive(false);
            }
            
        }
    }
}
