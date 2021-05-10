using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCanHolder : MonoBehaviour
{
    private List<GasCan.KeyType> gasCanList;
    public static int GasCanIndex;
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
        gasCanList.Add(gasCanType);
        GasCanIndex++;
        //Debug.Log($"Added key: {gasCanType} {GasCanIndex}");
        GasCanAmountText.text = $"{GasCanIndex}/3";
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
    }
}
