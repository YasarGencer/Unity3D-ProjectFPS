using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    //CONTROLLER SCRIPTS
    private PlayerMotor playerMotor;
    private PlayerLook playerLook;
    private PlayerWeaponManager playerWeapon;

    void Awake(){
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        playerWeapon = GetComponent<PlayerWeaponManager>();
        SetInputPerformed();
    }

    private void FixedUpdate() {
        //HANDLE MOVEMENT
        Vector3 currentDirection = onFoot.Movement.ReadValue<Vector2>();
        playerMotor.ProcessMovement(currentDirection);
    }
    private void LateUpdate() {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void SetInputPerformed(){
        onFoot.Jump.performed += ctx => playerMotor.Jump();
        onFoot.Shoot.performed += ctx => playerWeapon.Shoot();
        onFoot.Reload.performed += ctx => playerWeapon.Reload();

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
