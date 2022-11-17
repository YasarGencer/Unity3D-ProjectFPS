using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add event to object 
    public bool UseEvent;
    [Tooltip("Message shown when looking to the object")] public string promptMessage;

    //Will be called from player
    public void BaseInteract(){
        if(UseEvent)
            GetComponent<InteractionEvents>().OnInteract.Invoke(); 
        Interact();
    }
    protected virtual void Interact(){
        //override script
    }
}
