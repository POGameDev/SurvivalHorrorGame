using UnityEngine;

public class GasCan : MonoBehaviour
{
    [SerializeField] private KeyType gasCan;

    public enum KeyType
    {
        GasCan,
    }

    public KeyType GetGasCan()
    {
        return gasCan;
    }
}
