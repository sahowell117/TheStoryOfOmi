using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public NPC currentNPCScript = null;
    public PlayerMovement movement;
    public PlayerCombat combat;
    public Player player;
    void Update()
    {
        //pick it up
        if (Input.GetButtonDown("Interact")) {
            //Check to see if this is an inanimate object
            if (currentInterObjScript != null) {
                //can we pick up?
                if (currentInterObjScript.inventory) {
                    player.inventory.PickupItem(currentInterObj);
                }
                else if (currentInterObjScript.talks && !GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking)
                {
                    //enter talk mode, no moving until exiting talk mode
                    currentInterObjScript.StartTalking();
                    GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking = true;

                }
                else if (currentInterObjScript.talks && GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking)
                {
                    //leave talk mode, move freely
                    currentInterObjScript.StopTalking();
                    GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking = false;

                }
            }
            //Check to see if this is an NPC
            else if (currentNPCScript != null && !GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking)
            {
                GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking = true;
                currentNPCScript.StartTalking();
            }
        }
        


        //Eat Apple
        if (Input.GetButtonDown("Consume"))
        {
            Debug.Log("checking...");
            GameObject apple = player.inventory.FindItemByType("consumable");
            Debug.Log("item found in inventory");
            if (apple != null)
            {
                player.currentHealth += 10;
                player.UpdateHealth();
                player.inventory.RemoveItem(apple);
            }
        }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("InterObject"))
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>(); //grabbing the game objects script
        }
        else if (other.CompareTag("NPC"))
        {
            currentInterObj = other.gameObject;
            currentNPCScript = currentInterObj.GetComponent<NPC>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") || other.CompareTag("NPC") || other.CompareTag("GrandmaMerchant"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
                currentInterObjScript = null;
                currentNPCScript = null;
            }
        }
    }
}
