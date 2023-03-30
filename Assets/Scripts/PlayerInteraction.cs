using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject currentInterObj = null;

    [SerializeField]
    private InteractionObject currentInterObjScript = null;


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentInterObj == true)
        {
            CheckInteraction();

        }
    }

    public void CheckInteraction()
    {
        if (currentInterObjScript.interType == InteractionObject.InteractableType.nothing)
        { currentInterObjScript.Nothing();  }

        else if (currentInterObjScript.interType == InteractionObject.InteractableType.info)
        { currentInterObjScript.Info(); }

        else if (currentInterObjScript.interType == InteractionObject.InteractableType.pickup)
        { currentInterObjScript.Pickup(); }

        else if (currentInterObjScript.interType == InteractionObject.InteractableType.dialogue)
        { currentInterObjScript.Dialogue(); }

        else if (currentInterObjScript.interType == InteractionObject.InteractableType.pickupinfo)
        { currentInterObjScript.PickUpInfo(); }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentInterObj = null;
        currentInterObjScript = null;
    }

}
