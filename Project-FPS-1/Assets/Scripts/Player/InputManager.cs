using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    //contoller scripts
    private PlayerMotor playerMotor;
    private PlayerLook playerLook;

    void Awake(){
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        SetInputPerformed();
    }

    private void FixedUpdate() {
        //get walking movement
        Debug.Log("INPUT DIRECTIONS =  " + onFoot.Movement.ReadValue<Vector2>());
        playerMotor.ProcessMovement(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate() {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void SetInputPerformed(){
        onFoot.Jump.performed += ctx => playerMotor.Jump();
    }
    #region ENABLES
    private void OnEnable() {
        onFoot.Enable();
    }
    private void OnDisable() {
        onFoot.Disable();
    }
    #endregion
    #region GETTER SETTERS
    public PlayerInput.OnFootActions GetOnFoot(){
        return onFoot;
    }
    #endregion
}
