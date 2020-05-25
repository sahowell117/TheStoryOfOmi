using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogue;

    public TextMeshProUGUI[] playerOptions;
    void Start()
    {
            dialogue.transform.parent.gameObject.SetActive(false);
            foreach (TextMeshProUGUI playerOption in playerOptions)
            {
               playerOption.transform.parent.gameObject.SetActive(false);
            }
    }

    public void StartTalking(string message)
    {
        dialogue.transform.parent.gameObject.SetActive(true);
        dialogue.text = message;
    }
}
