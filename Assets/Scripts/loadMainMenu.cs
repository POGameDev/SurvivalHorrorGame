using UnityEngine;

public class loadMainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;

    PlayerMovement _player;
    FlashLight _flashLight;
    KeyHolder _keyHolder;
    private bool isActive;

    public loadMainMenu(PlayerMovement player, FlashLight flashLight, KeyHolder keyHolder)
    {
        _player = player;
        _flashLight = flashLight;
        _keyHolder = keyHolder;
    }
    void Start()
    {
        mainMenuCanvas.SetActive(false);
        isActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && !isActive)
        {
            Pause();
        }
        else if (Input.GetKeyDown("escape") && isActive)
        {
            Resume();
        }

    }

    void Pause()
    {
        mainMenuCanvas.SetActive(true);
        isActive = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    void Resume()
    {
        mainMenuCanvas.SetActive(false);
        isActive = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
