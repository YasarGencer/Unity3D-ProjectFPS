using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;
    private PlayerUI playerUI;
    private InputManager _inputManager;
    private void Start() {
        _cam = GetComponent<PlayerLook>().Cam;
        playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }
    private void Update() {
        //create a ray
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        //clear promp text ui
        playerUI.SetText(playerUI.GetPrompText(), string.Empty);
        //get collision info and make it interactable
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo,_distance,_mask))
            if(hitInfo.collider.GetComponent<Interactable>() != null)
                OnInteractable(hitInfo.collider.GetComponent<Interactable>());
    }
    private void OnInteractable(Interactable interactable){
        string text = "[" +  interactable.promptMessage + "]";
        playerUI.SetText(playerUI.GetPrompText(),text);
        if(_inputManager.GetOnFoot().Interact.triggered)
            interactable.BaseInteract();
    }
}
