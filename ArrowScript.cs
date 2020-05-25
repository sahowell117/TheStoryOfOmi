using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (!other.CompareTag("Player"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver); // not everything can take damage
            Destroy(gameObject);
        }
    }
}
