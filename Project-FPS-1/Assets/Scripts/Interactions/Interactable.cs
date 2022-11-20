using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add event to object 
    public bool UseEvent;
    public bool OnTouch = false;
    public bool OneTimeOnly = false;
    [Tooltip("Message shown when looking to the object")] public string PromptMessage;

    //Will be called from player
    public void BaseInteract(){
        if(UseEvent)
            GetComponent<InteractionEvents>().OnInteract.Invoke(); 
        Interact();
    }
    protected virtual void Interact(){
        //override script
    }
    public virtual void PrompText() {
        string text = "[" + PromptMessage + "]";
        PlayerUI.Instance.SetText(PlayerUI.Instance.GetPrompText(), text);
    }
}
