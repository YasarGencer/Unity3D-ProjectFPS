using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{

    [SerializeField] private Animator _door;
    [SerializeField] private float _animationTimer = 1f;
    private bool _isOpen = false, _isInteractable = true;

    //PROMPT TEXTS
    [SerializeField, Tooltip("Do not change if needed")] string _openT = "Open The Door";
    [SerializeField, Tooltip("Do not change if needed")] string _closeT = "Close The Door";
    [SerializeField, Tooltip("Do not change if needed")] string _waitT = "Please Wait";
    private void Start() {
        promptMessage = _openT;
    }
    protected override void Interact(){
        if(_isInteractable){
            if(_isOpen)
                CloseDoor();
            else
                OpenDoor();
        }
    }
    private void OpenDoor(){
        _door.SetTrigger("Open");
        _isOpen = true;
        StartCoroutine(SetUnInteractable(_closeT));
    }
    private void CloseDoor(){
        _door.SetTrigger("Close");
        _isOpen = false;
        StartCoroutine(SetUnInteractable(_openT));
    }
    IEnumerator SetUnInteractable(string prompt){
        promptMessage = _waitT;
        _isInteractable = false;
        yield return new WaitForSeconds(_animationTimer);
        NavBaker.Instance.BAKE();
        promptMessage = prompt;
        _isInteractable = true;
    }
}
