using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory {

    public GameObject[] inventory;
 
    public Inventory(int size)
    {
        this.inventory = new GameObject[size];
    }
    public void AddItem(GameObject item) {
        //Find first open slot in inventory
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                inventory[i] = item;
                //Do something with object
                //InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }

    public void PickupItem(GameObject item)
    {
        bool wasAdded = false;
        //Find first open slot in inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                //Do something with object
                //InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                item.SendMessage("DoInteraction");
                Debug.Log(item.name + "was added");
                wasAdded = true;
                break;
            }
        }
        if (!wasAdded)
        {
            Debug.Log("inventory was full");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true; 
            }
        }
        return false; 
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                {
                    return inventory[i];
                }
            }
        }
        return null; 
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
                //InventoryButtons[i].image.overrideSprite = null;//item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was removed from inventory");
                break;
            }
        }
    }
}
