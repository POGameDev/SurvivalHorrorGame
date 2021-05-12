using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HealthBar;
    public static int Health = 80;
    public GameObject gameOverScreen;
    void Start()
    {
        gameOverScreen.SetActive(false);
        HealthUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUpdate();
        Dead();
    }

    private void HealthUpdate()
    {
        HealthBar.text = Health.ToString();
    }

    private void Dead()
    {
        if (Health == 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
