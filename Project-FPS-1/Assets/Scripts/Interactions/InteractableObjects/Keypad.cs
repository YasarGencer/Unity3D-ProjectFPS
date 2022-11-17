using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private GameObject _door;
    [SerializeField] private float _animationTimer = 1f;
    private Animator _doorAnim;
    private bool _isOpen = false, _isInteractable = true;
    [SerializeField, Tooltip("Do not change if needed")] string _openT = "Open The Door";
    [SerializeField, Tooltip("Do not change if needed")] string _closeT = "Close The Door";
    [SerializeField, Tooltip("Do not change if needed")] string _waitT = "Please Wait";
    private void Start() {
        _doorAnim = _door.GetComponent<Animator>();
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
        _doorAnim.SetTrigger("Open");
        _isOpen = true;
        StartCoroutine(SetUnInteractable(_closeT));
    }
    private void CloseDoor(){
        _doorAnim.SetTrigger("Close");
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
