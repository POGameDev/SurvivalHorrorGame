using UnityEngine;

public class loadMainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;

    void Start()
    {
        mainMenuCanvas.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) 
        //{
        //    mainMenuCanvas.SetActive(true);
        //}

        if (Input.GetKeyDown("escape"))
        {
            mainMenuCanvas.SetActive(true);
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
