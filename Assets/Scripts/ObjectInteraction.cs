using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject weaponHolder;

    public string massage = "Press F to pick up ";
    public TMP_Text massageTxt;

    RaycastHit obj;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out obj))
        {
            InteractableObjects interactableObject = obj.transform.GetComponent<InteractableObjects>();
            EnemiesSpawn enemiesSpawn = obj.transform.GetComponent<EnemiesSpawn>();

            if (interactableObject != null)
            {                
                massageTxt.text = massage + " " + interactableObject.weaponName;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    weaponHolder.GetComponent<WeaponSwither>().SelectWeapon(interactableObject.ID);
                }
            }
            else if (enemiesSpawn != null)
            {
                massageTxt.text = "Shoot to interact";
                massageTxt.color = Color.black;
                if (Input.GetMouseButtonDown(0))
                {
                    enemiesSpawn.TestColorChanger();
                }
            }
            else
            {
                massageTxt.text = "";
            }

            
        }
        
    }
}
