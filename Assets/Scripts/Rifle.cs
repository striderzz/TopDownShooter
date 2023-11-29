using UnityEngine;
using System.Collections;
using TMPro;
public class Rifle : MonoBehaviour
{
    public Transform firePoint;          // The point from which the bullets are fired.
    public GameObject bulletPrefab;      // Prefab for the bullet projectile.
    public float fireRate = 0.1f;        // Rate of fire in shots per second.
    public float reloadTime = 1.0f;      // Time it takes to reload in seconds.
    public int maxAmmo = 30;             // Maximum ammo capacity.
    private int currentAmmo;             // Current ammo count.
    private float nextFireTime = 0f;    // Time when the next shot can be fired.
    private bool isReloading = false;    // Is the rifle currently reloading?
    public AudioSource rifleFire;
    public AudioSource rifleReload;

    public TMP_Text weaponName;
    public TMP_Text ammoCount;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        weaponName.text = "Rifle";
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

        if (Time.time >= nextFireTime)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        UpdateAmmoDisplay();
    }

    void Shoot()
    {
        rifleFire.Play();
        currentAmmo--;
     

        // Create a bullet from the bullet prefab.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 5f);
    }

    IEnumerator Reload()
    {
        rifleReload.Play();
        isReloading = true;
        // Play a reload animation or sound here if desired.

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        
        isReloading = false;
    }
    public void UpdateAmmoDisplay()
    {
        ammoCount.text = currentAmmo + "/" + maxAmmo;
    }
}
