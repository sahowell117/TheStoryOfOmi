using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt anmiation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //die animation
        animator.SetBool("IsDead", true);

        //disable the enemy
        this.enabled = false; //this disables the script, but we could still run into the body sooooo
        GetComponent<Collider2D>().enabled = false;

    }

}
