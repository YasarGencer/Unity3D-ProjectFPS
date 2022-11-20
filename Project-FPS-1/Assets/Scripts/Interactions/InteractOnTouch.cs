using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Interactable interactable = collision.gameObject.GetComponent<Interactable>();
        if(interactable != null)
            interactable.BaseInteract();
    }
}
