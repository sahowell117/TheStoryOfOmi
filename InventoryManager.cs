using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public Button[] vendorSlots;
    public Button[] playerSlots;
    public TextMeshProUGUI itemTitle;
    public TextMeshProUGUI itemDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        vendorSlots[0].transform.parent.gameObject.SetActive(false);
        foreach (Button vendorSlot in vendorSlots)
        {
            vendorSlot.gameObject.SetActive(false);
        }
        foreach (Button playerSlot in playerSlots)
        {
            playerSlot.gameObject.SetActive(false);
        }
        itemTitle.transform.parent.gameObject.SetActive(false);
    }
}
