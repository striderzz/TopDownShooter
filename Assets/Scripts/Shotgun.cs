using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject pelletPrefab;
    public int pelletCount = 5;  // Number of pellets per shot
    public float spreadAngle = 15f;  // Spread angle of pellets
    public float pelletSpeed = 10f;  // Speed of pellets
    public int minDamage = 10;
    public int maxDamage = 20;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Change the input button as needed
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            // Calculate a random spread direction within the specified angle
            float angle = firePoint.rotation.eulerAngles.z + Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

            // Create a pellet and set its damage
            GameObject pellet = Instantiate(pelletPrefab, firePoint.position, Quaternion.identity);
            PelletScript pelletScript = pellet.GetComponent<PelletScript>();
            pelletScript.SetDamage(Random.Range(minDamage, maxDamage + 1)); // Inclusive range

            // Move the pellet using transform.translate
            MovePellet(pellet.transform, direction * pelletSpeed);
        }
    }

    private void MovePellet(Transform pelletTransform, Vector2 velocity)
    {
        float distance = 0f;

        while (distance < pelletSpeed * Time.deltaTime)
        {
            pelletTransform.Translate(velocity * Time.deltaTime);
            distance += velocity.magnitude * Time.deltaTime;
            // You can add collision detection logic here if needed
        }
    }
}
