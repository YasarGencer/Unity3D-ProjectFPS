using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private void Start() {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }
    private void Update() {
        //create a ray
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        //clear promp text ui
        playerUI.SetText(playerUI.GetPrompText(), string.Empty);
        //get collision info and make it interactable
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo,distance,mask))
            if(hitInfo.collider.GetComponent<Interactable>() != null)
                OnInteractable(hitInfo.collider.GetComponent<Interactable>());
    }
    private void OnInteractable(Interactable interactable){
        playerUI.SetText(playerUI.GetPrompText(),interactable.promptMessage);
        if(inputManager.GetOnFoot().Interact.triggered)
            interactable.BaseInteract();
    }
}
