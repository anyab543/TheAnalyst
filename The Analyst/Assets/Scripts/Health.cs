using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool isPlayer = false;
    
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
        if ((currentHealth <= 0)&&(isPlayer)){
            SceneManager.LoadScene("EndLose");
        }
    }


    public void Heal(int amount) {
        currentHealth += amount;
        if (currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }
    }

}
