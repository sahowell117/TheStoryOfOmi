using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public bool openable;
    public bool locked;
    public bool talks;          //true if obj has dialogue
    public string itemType;
    public int value;           //how much money its worth
    // Start is called before the first frame update
    public GameObject itemNeeded;
    public Animator anim;
    public string message;

    public void DoInteraction()
    {
        if (gameObject.activeSelf)
        gameObject.SetActive(false);

    }
    // Update is called once per frame
    public void Open()
    {
        anim.SetBool("open", true);
    }


    public void StartTalking()
    {

        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.StartTalking(message);

    }

    public void StopTalking()
    {
        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.text = "";
        GameObject.FindObjectOfType<GlobalVariables>().dialogueManager.dialogue.transform.parent.gameObject.SetActive(false);
    }
}
