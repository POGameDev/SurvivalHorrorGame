using UnityEngine;

public class TankCube : MonoBehaviour
{
    public Camera fpsCamera;
    public GameObject tankUpText;
    public GameObject gameEndText;
    private readonly float tankUpRange = 4.0f;

    void Start()
    {
        tankUpText.SetActive(false);
        gameEndText.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, tankUpRange))
        {
            if (hit.transform.name == "TankCube")
            {
                tankUpText.SetActive(true);
                if (Input.GetKeyDown("e") && GasCanHolder.GasCanIndex == 3)
                {
                    Debug.Log("Tankowanie!");
                    gameEndText.SetActive(true);
                    
                }
            }
        }
        else
        {
            tankUpText.SetActive(false);
        }
    }
}
