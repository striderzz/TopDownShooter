using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;             // Maximum health of the player.
    public int currentHealth;              // Current health of the player.
    //public Text healthText;
    public Image healthbar;
    // UI Text element to display player health.

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    private void Update()
    {
        UpdateHealthUI();
    }
    // Apply damage to the player.
    public void TakeDamage(int damage)
    {
        // Subtract the damage from the current health.
        currentHealth -= damage;

        // Ensure that health doesn't go below 0.
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthUI();

        // Check if the player's health has reached zero.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Handle the player's death.
    void Die()
    {
        // Perform any death-related actions here, such as game over logic, animations, etc.
        Debug.Log("Player has died");

        // Disable the player's GameObject or perform other actions as needed.
        gameObject.SetActive(false);
    }

    // Update the UI to display the player's current health.
    void UpdateHealthUI()
    {
        
        healthbar.fillAmount = Mathf.Clamp01((float)currentHealth / (float)maxHealth);

    }
}
