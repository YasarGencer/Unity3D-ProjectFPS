using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public GameObject door;
    [SerializeField] float animationTimer = 1f;
    Animator doorAnim;
    private bool isOpen = false, isInteractable = true;
    [SerializeField, Tooltip("Do not change if needed")] string openT = "Open The Door";
    [SerializeField, Tooltip("Do not change if needed")] string closeT = "Close The Door";
    [SerializeField, Tooltip("Do not change if needed")] string waitT = "Please Wait";
    private void Start() {
        doorAnim = door.GetComponent<Animator>();
        promptMessage = openT;
    }
    protected override void Interact(){
        if(isInteractable){
            if(isOpen)
                CloseDoor();
            else
                OpenDoor();
        }
    }
    private void OpenDoor(){
        doorAnim.SetTrigger("Open");
        isOpen = true;
        StartCoroutine(SetUnInteractable(closeT));
    }
    private void CloseDoor(){
        doorAnim.SetTrigger("Close");
        isOpen = false;
        StartCoroutine(SetUnInteractable(openT));
    }
    IEnumerator SetUnInteractable(string prompt){
        promptMessage = waitT;
        isInteractable = false;
        yield return new WaitForSeconds(animationTimer);
        NavBaker.Instance.BAKE();
        promptMessage = prompt;
        isInteractable = true;
    }
}
