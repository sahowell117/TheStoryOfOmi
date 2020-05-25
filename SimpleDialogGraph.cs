using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogGraph { 



    private Dictionary<int, DialogNode> _nodes = new Dictionary<int, DialogNode>();

    public void AddNode(DialogNode node)
    {
        _nodes[node.id] = node;
    }

    public bool RemoveNode(DialogNode node)
    {
        DialogNode other;
        if (_nodes.TryGetValue(node.id, out other))
        {
            if (node == other)
            {
                _nodes.Remove(node.id);
                return true;
            }
        }

        return false;
    }

    public DialogNode GetNode(int id)
    {
        DialogNode node;
        if (_nodes.TryGetValue(id, out node))
        {
            return node;
        }

        return null;
    }

}

public class DialogNode
{
    public int id; 
    public string message;
    public List<int> neighbours;
    public string who;
    public string descriptor;
    public string itemTypeToGive;
    public bool endsConvo;
    public DialogNode(int id, string message, List<int> list, speaker speaker, string descriptor, string itemTypeToGive, bool endsConvo)
    {
        this.id = id;
        this.message = message;
        this.neighbours = list;
        this.who = speaker.ToString();
        this.descriptor = descriptor;
        this.itemTypeToGive = itemTypeToGive;
        this.endsConvo = endsConvo; 
    }

    public enum speaker
    {
        NPC,
        Player
    }
}
