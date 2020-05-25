using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NPC : MonoBehaviour
{
    public bool attackable;
    public bool health;
    public Quest quest;
    public float pierceDamage;
    public float bludgeonDamage;
    public float poisonLevel;
    public Player player;
    public bool IamTalking;
    public bool IamVending;
    //public DialogueManager dialogueManager;
    public SimpleDialogGraph simpleDialogGraph;
    private LinkedList<DialogNode> activeNodes = new LinkedList<DialogNode>();
    private LinkedListNode<DialogNode> currentNode;
    public string message;
    public float talkingSpeed;
    private int highlight = 0;
    public Inventory inventory;

    IEnumerator Type(string message)
    {
        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.text = "";
        foreach (char letter in message.ToCharArray())
        {
            GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.text += letter;
            yield return new WaitForSeconds(talkingSpeed);
        }
    }

    private void Update()
    {
        if (IamTalking && !IamVending)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && currentNode.Next != null) //not already at the bottom of the options list
            {
                currentNode = currentNode.Next;
                GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[highlight].faceColor = Color.red;
                GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[highlight + 1].faceColor = Color.green;
                highlight += 1;
                //dialogueManager.playerOption1.material.color = color;   //changes the background of the inventory to green for some reason
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && currentNode.Previous != null)  //not already at the top of the options list
            {
                currentNode = currentNode.Previous;
                GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[highlight].faceColor = Color.red;
                GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[highlight - 1].faceColor = Color.green;
                highlight -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                if (currentNode.Value.descriptor.Equals("giveItem"))
                {
                    GameObject item = player.inventory.FindItemByType(currentNode.Value.itemTypeToGive);
                    this.inventory.AddItem(item);
                    player.inventory.RemoveItem(item);
                    DisplayConversation(simpleDialogGraph.GetNode(currentNode.Value.neighbours.ToArray()[0]));
                }
                else if (currentNode.Value.descriptor.Equals("shop"))
                {
                    this.IamVending = true;
                    GameObject.FindObjectOfType<GlobalVariables>().playerIsVending = true; 
                    DisplayConversation(simpleDialogGraph.GetNode(currentNode.Value.neighbours.ToArray()[0]));
                }
                else if (currentNode.Value.endsConvo)
                {
                    ResetCanvas();
                    GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking = false;
                    IamTalking = false;
                }
                else
                {
                    DisplayConversation(simpleDialogGraph.GetNode(currentNode.Value.neighbours.ToArray()[0]));
                }
            }
        }
        if (IamVending)
        {
        //inventory.InventoryButtons[0].transform.parent.gameObject.SetActive(true);
        int i = 0;
       // foreach (Button vendorSlot in inventory.InventoryButtons)
       // {
       //     if (i < inventory.inventory.Length)
        //    vendorSlot.gameObject.SetActive(true);
       //     i++;
       // }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) //not already at the bottom of the options list
            {
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) //not already at the bottom of the options list
            {
            }
        }
    }

    public void DisplayConversation(DialogNode node)
    {
        ResetCanvas();
        if (node != null)
        {
            GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.transform.parent.gameObject.SetActive(true);
            StartCoroutine(Type(node.message));
            if (node.neighbours != null && node.neighbours.Count > 0)
            {
                int i = 0;
                foreach (int neighbor in node.neighbours)
                {
                    if (simpleDialogGraph.GetNode(neighbor).descriptor.Equals("") || simpleDialogGraph.GetNode(neighbor).descriptor.Equals("shop") || (!simpleDialogGraph.GetNode(neighbor).itemTypeToGive.Equals("") && player.inventory.FindItemByType(simpleDialogGraph.GetNode(neighbor).itemTypeToGive) != null))
                    {
                        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[i].transform.parent.gameObject.SetActive(true);
                        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[i].text = simpleDialogGraph.GetNode(neighbor).message;
                        activeNodes.AddLast(simpleDialogGraph.GetNode(neighbor));
                        i++;
                    }
                }
                GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions[0].faceColor = Color.green;
                currentNode = activeNodes.First;
            }
        }
    }

    public void StartTalking()
    {
        DisplayConversation(simpleDialogGraph.GetNode(1));
        IamTalking = true;
        GameObject.FindObjectOfType<GlobalVariables>().playerIsTalking = true;
    }

    public void ResetCanvas()
    {
        highlight = 0;
        activeNodes = new LinkedList<DialogNode>();
        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.text = "";
        foreach (TextMeshProUGUI playerOption in GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.playerOptions)
        {
            playerOption.text = "";
            playerOption.faceColor = Color.red;
            playerOption.transform.parent.gameObject.SetActive(false);
        }
        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.transform.parent.gameObject.SetActive(false);
    }
}
