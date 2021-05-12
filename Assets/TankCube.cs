using UnityEngine;

public class TankCube : MonoBehaviour
{
    public Camera fpsCamera;
    public GameObject tankUpText;
    public GameObject gameEndText;
    public GameObject noGasCanText;
    private readonly float tankUpRange = 4.0f;

    void Start()
    {
        tankUpText.SetActive(false);
        gameEndText.SetActive(false);
        noGasCanText.SetActive(false);
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
                    gameEndText.SetActive(true);
                }
                else if (Input.GetKeyDown("e") && GasCanHolder.GasCanIndex < 3)
                {
                    noGasCanText.SetActive(true);
                }
            }
        }
        else
        {
            tankUpText.SetActive(false);
            noGasCanText.SetActive(false);
        }
    }
}
