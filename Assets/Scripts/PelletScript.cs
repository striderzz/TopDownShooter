using UnityEngine;

public class PelletScript : MonoBehaviour
{
    public int damage = 10;  // Damage dealt by the pellet (can be set in the Inspector)
    public float pelletSpeed = 10f;  // Speed at which the pellet moves
   // public GameObject impactEffect; // Particle effect to spawn on impact (optional)

    private Vector3 initialPosition;  // Initial position of the pellet

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Move the pellet forward based on its initial position and speed
        transform.Translate(Vector3.up * pelletSpeed * Time.deltaTime);

        // Check if the pellet has traveled a certain distance (e.g., 10 meters) and destroy it
        if (Vector3.Distance(initialPosition, transform.position) >= 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the pellet collided with a damageable object
        if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        /*
        // Spawn an impact effect (optional)
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        */

        // Destroy the pellet
        Destroy(gameObject);
    }

    // Setter method for setting the pellet's damage from the Shotgun script
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
