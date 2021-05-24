using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMethods : MonoBehaviour
{
    public Button saveBtn;
    public Button LoadBtn;

    //private readonly loadMainMenu _loadMainMenu;
    //public ButtonsMethods(loadMainMenu loadMainMenu)
    //{
    //    _loadMainMenu = loadMainMenu;
    //}

    public void PressSaveButton()
    {
        //_loadMainMenu.SaveGameData();
        Debug.Log("Save");
    }

    public void PressLoadButton()
    {
        //_loadMainMenu.LoadGameData();
        Debug.Log("Load");
    }
}
