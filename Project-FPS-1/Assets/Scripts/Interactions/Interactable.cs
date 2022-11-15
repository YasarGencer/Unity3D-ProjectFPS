using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add event to object 
    public bool useEvent;
    [TextArea, Tooltip("Message shown when looking to the object")] public string promptMessage;

    //Will be called from player
    public void BaseInteract(){
        if(useEvent)
            GetComponent<InteractionEvents>().OnInteract.Invoke(); 
        Interact();
    }
    protected virtual void Interact(){
        //override script
    }
}
