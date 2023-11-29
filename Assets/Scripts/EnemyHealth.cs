using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;       // Maximum health of the enemy.
    private int currentHealth;        // Current health of the enemy.

    // Initialize the enemy's health.
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Apply damage to the enemy.
    public void TakeDamage(int damage)
    {
        // Subtract the damage from the current health.
        currentHealth -= damage;

        // Check if the enemy's health has reached zero or below.
        if (currentHealth <= 0)
        {
            // Call a method to handle the enemy's death.
            Die();
        }
    }

    // Handle the enemy's death.
    void Die()
    {
        // Perform any death-related actions here, such as playing death animations, dropping loot, etc.

        // Destroy the enemy GameObject.
        Destroy(gameObject);
    }
}
