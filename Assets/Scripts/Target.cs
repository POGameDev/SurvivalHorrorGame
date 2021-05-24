using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject thisGameObject;
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(thisGameObject);
    }
}
