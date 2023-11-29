using UnityEngine;

public enum PickupType
{
    Weapon,
    HealthBox
}

public class Pickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    public PickupType pickupType;
    public string weaponName; // Used for Weapon type
    public int healthValue = 25; // Only used for HealthBox type

    private const string PistolWeaponName = "Pistol";
    private const string RifleWeaponName = "Rifle";
    // Add more constants for future weapon names as needed

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth component not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case PickupType.Weapon:
                    HandleWeaponPickup();
                    break;

                case PickupType.HealthBox:
                    HandleHealthBoxPickup();
                    break;
            }

            //Destroy(gameObject);
        }
    }

    private void HandleWeaponPickup()
    {
        if (weaponName == PistolWeaponName)
        {
            Debug.Log("Picked up weapon: " + weaponName);
            PlayerWeaponManager.instance.ChangeWeapon(0);
        }
        else if (weaponName == RifleWeaponName)
        {
            Debug.Log("Picked up weapon: " + weaponName);
            PlayerWeaponManager.instance.ChangeWeapon(1);
        }
        // Add more cases for future weapon names
    }

    private void HandleHealthBoxPickup()
    {
        if (playerHealth != null)
        {
            if (playerHealth.currentHealth < 100) // Check if health is less than 100
            {
                int healthToAdd = Mathf.Min(100 - playerHealth.currentHealth, healthValue);
                playerHealth.currentHealth += healthToAdd;
                Debug.Log("Picked up health box: +" + healthToAdd + " health");
            }
            else
            {
                Debug.Log("Health is already full. Health box not used.");
            }
        }
    }

}
