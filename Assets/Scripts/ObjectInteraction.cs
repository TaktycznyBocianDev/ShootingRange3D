using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{

    public string massage = "Press F to pick up ";
    public TMP_Text massageTxt;

    RaycastHit obj;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out obj))
        {
            InteractableObjects interactableObject = obj.transform.GetComponent<InteractableObjects>();

            if (interactableObject != null)
            {                
                massageTxt.text = massage + " " + interactableObject.weaponName;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log(interactableObject.ID);
                }
            }
            else
            {
                massageTxt.text = "";
            }

            
        }
        
    }
}
