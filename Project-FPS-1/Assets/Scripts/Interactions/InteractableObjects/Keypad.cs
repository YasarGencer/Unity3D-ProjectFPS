using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public GameObject door;
    [SerializeField] float animationTimer = 1f;
    Animator doorAnim;
    private bool isOpen = false, isInteractable = true;
    private void Start() {
        doorAnim = door.GetComponent<Animator>();
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
        StartCoroutine(SetUnInteractable("Close The Door"));
    }
    private void CloseDoor(){
        doorAnim.SetTrigger("Close");
        isOpen = false;
        StartCoroutine(SetUnInteractable("Open The Door"));
    }
    IEnumerator SetUnInteractable(string prompt){
        promptMessage = "Please Wait";
        isInteractable = false;
        yield return new WaitForSeconds(animationTimer);
        promptMessage = prompt;
        isInteractable = true;
    }
}
