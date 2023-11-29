using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager instance;

    public GameObject[] weapons;
    public int startweaponNumber;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (GameObject g in weapons)
        {
            g.SetActive(false);
        }
        weapons[startweaponNumber].SetActive(true);
    }

    public void ChangeWeapon(int weaponNumber)
    {
        foreach(GameObject g in weapons)
        {
            g.SetActive(false);
        }
        weapons[weaponNumber].SetActive(true);
    }
}
