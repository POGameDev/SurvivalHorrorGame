using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCanHolder : MonoBehaviour
{
    private List<GasCan.KeyType> gasCanList;
    private int GasCanIndex;
    public Text GasCanAmountText;

    void Start()
    {
        GasCanAmountText.text = null;
    }
    private void Awake()
    {
        gasCanList = new List<GasCan.KeyType>();
    }

    public void AddKey(GasCan.KeyType gasCanType)
    {
        //Debug.Log($"Added key: {gasCanType} {GasCanIndex}");
        gasCanList.Add(gasCanType);
        GasCanIndex++;
        Debug.Log($"Added key: {gasCanType} {GasCanIndex}");
        GasCanAmountText.text = GasCanIndex.ToString();
    }

    public void RemoveKey(GasCan.KeyType gasCanType)
    {
        gasCanList.Remove(gasCanType);
    }

    public bool ContainsKey(GasCan.KeyType gasCanType)
    {
        return gasCanList.Contains(gasCanType);
    }

    private void OnTriggerEnter(Collider collider)
    {
        GasCan gasCan = collider.GetComponent<GasCan>();
        if (gasCan != null)
        {
            AddKey(gasCan.GetGasCan());
            Destroy(gasCan.gameObject);
        }

        //KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        //if (keyDoor != null)
        //{
        //    if (ContainsKey(keyDoor.GetKeyType()))
        //    {
        //        RemoveKey(keyDoor.GetKeyType());
        //        keyDoor.OpenDoor();
        //    }
        //}
    }
}
