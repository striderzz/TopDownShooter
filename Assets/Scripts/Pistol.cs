using UnityEngine;
using System.Collections;
using TMPro;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;          // The point from which the bullets are fired.
    public GameObject bulletPrefab;      // Prefab for the bullet projectile.
    public float fireRate = 0.5f;        // Rate of fire in shots per second.
    private float nextFireTime = 0f;    // Time when the next shot can be fired.
    public AudioSource pistolFire;
    public AudioSource pistolReload;
    public float reloadTime = 1f;

    public int maxAmmo = 10;             // Maximum ammo capacity in a clip.
    private int currentAmmo;             // Current ammo count in the clip.
    private bool isReloading = false;    // Is the pistol currently reloading?

    public TMP_Text weaponName;
    public TMP_Text ammoCount;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        weaponName.text = "9mm Pistol";
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            // Out of ammo, trigger a reload.
            StartCoroutine(Reload());
            return;
        }
        // Check if it's time to fire a shot.
        if (Time.time >= nextFireTime)
        {
            // Fire a bullet when the player presses the fire button (e.g., left mouse button).
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                // Set the next fire time based on the fire rate.
                nextFireTime = Time.time + 1f / fireRate;
                currentAmmo--; // Deduct one bullet from the clip.
                pistolFire.Play();

            
            }
            // Reload when the player presses the reload button (e.g., R key).
            
        }

        UpdateAmmoDisplay();
    }

    void Shoot()
    {
        // Create a bullet from the bullet prefab.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 5f);
    }

    IEnumerator Reload()
    {
        pistolReload.Play();
        // If there are bullets left in the clip, play a reload sound.
       

        isReloading = true;

        // Simulate the reload time.
        yield return new WaitForSeconds(reloadTime); // Adjust the time as needed.

        // Reset the current ammo to the maximum ammo.
        currentAmmo = maxAmmo;
        isReloading = false;

    }
    public void UpdateAmmoDisplay()
    {
        ammoCount.text = currentAmmo + "/" + maxAmmo;
    }
}
