using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool isDead() {
        if (currentHealth <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
    }


    public void Heal(int amount) {
        currentHealth += amount;
        if (currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }
    }

}
