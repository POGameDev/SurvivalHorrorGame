using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    public GameObject weapons;
    public GameObject player;

    private float pickUpRange = 3.0f;
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
                child.SetActive(false);
            }
            
        }
    }
}
