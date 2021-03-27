using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HealthBar;
    public static int Health = 80;
    void Start()
    {
        HealthUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUpdate();
    }

    private void HealthUpdate()
    {
        HealthBar.text = "HP: " + Health.ToString();
    }
}
