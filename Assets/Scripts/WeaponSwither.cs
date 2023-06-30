using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwither : MonoBehaviour
{
    public GameObject[] weapons;

    public void SelectWeapon(int WeaponID)
    {
        int i = 0;
        foreach (var weapon in weapons)
        {
            if (i == WeaponID)
            {
                weapon.SetActive(true);
            }
            else
                weapon.SetActive(false);

            i++;
        }
    }
}
