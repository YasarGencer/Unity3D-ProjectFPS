using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [TextArea, Tooltip("Message shown when looking to the object")] public string promptMessage;

    //Will be called from player
    public void BaseInteract(){
        Interact();
    }
    protected virtual void Interact(){
        //override script
    }
}
