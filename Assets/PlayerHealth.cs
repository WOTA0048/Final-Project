using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("RIP");
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        var hit = coll.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
    }
}
