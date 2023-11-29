using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet.
    public int damageAmt = 5;

    // Update is called once per frame.
    void Update()
    {
        // Move the bullet forward based on its speed.
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // Called when the bullet collides with something.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet when it hits an object (e.g., an enemy, wall).
        Destroy(gameObject);
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damageAmt);
        }

        // You can add additional logic here, such as dealing damage to the object hit.
        // Example: if (collision.CompareTag("Enemy")) { enemy.TakeDamage(damageAmount); }
    }
   
}
