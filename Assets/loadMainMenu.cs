using UnityEngine;

public class loadMainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    private bool isActive;

    void Start()
    {
        mainMenuCanvas.SetActive(false);
        isActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && !isActive)
        {
            mainMenuCanvas.SetActive(true);
            isActive = true;
        }
        else if (Input.GetKeyDown("escape") && isActive)
        {
            mainMenuCanvas.SetActive(false);
            isActive = false;
        }
    }

    public void SaveGameData()
    {
        //SaveData.Save();
    }

    public void LoadGameData()
    {
        PlayerData data = SaveData.LoadData();
    }
}
