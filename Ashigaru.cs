using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashigaru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimpleDialogGraph simpleDialogGraph = new SimpleDialogGraph();
        Inventory inventory = new Inventory(8);

        DialogNode node1 = new DialogNode(1, "Man I could really use an apple...", new List<int> { 2, 3, 4 }, DialogNode.speaker.NPC, "", "", false);
        DialogNode node2 = new DialogNode(2, "Here's one!", new List<int> { 5 }, DialogNode.speaker.Player, "giveItem", "consumable", false);
        DialogNode node3 = new DialogNode(3, "Can't we all", new List<int> { 6 }, DialogNode.speaker.Player, "", "", false);
        DialogNode node4 = new DialogNode(4, "I like shorts", new List<int> { 7 }, DialogNode.speaker.Player, "", "", false);
        DialogNode node5 = new DialogNode(5, "Wow thanks!", new List<int> { 8 }, DialogNode.speaker.NPC, "", "", false);
        DialogNode node6 = new DialogNode(6, "mhm", new List<int> { 9 }, DialogNode.speaker.NPC, "", "", false);
        DialogNode node7 = new DialogNode(7, "uhh....ok man", new List<int> { 9 }, DialogNode.speaker.NPC, "", "", false);
        DialogNode node8 = new DialogNode(8, "no problem", new List<int> { }, DialogNode.speaker.Player, "", "", true);
        DialogNode node9 = new DialogNode(9, "(leave)", new List<int> { }, DialogNode.speaker.Player, "", "", true);
        simpleDialogGraph.AddNode(node1);
        simpleDialogGraph.AddNode(node2);
        simpleDialogGraph.AddNode(node3);
        simpleDialogGraph.AddNode(node4);
        simpleDialogGraph.AddNode(node5);
        simpleDialogGraph.AddNode(node6);
        simpleDialogGraph.AddNode(node7);
        simpleDialogGraph.AddNode(node8);
        simpleDialogGraph.AddNode(node9);
        this.GetComponentInParent<NPC>().simpleDialogGraph = simpleDialogGraph;
        this.GetComponentInParent<NPC>().inventory = inventory; 
    }

}
