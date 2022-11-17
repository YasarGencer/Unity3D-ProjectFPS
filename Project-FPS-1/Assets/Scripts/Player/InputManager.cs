using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;

    //CONTROLLER SCRIPTS
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;
    private PlayerWeaponManager _playerWeapon;

    void Awake(){
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();
        _playerWeapon = GetComponent<PlayerWeaponManager>();
        SetInputPerformed();
    }

    private void FixedUpdate() {
        //HANDLE MOVEMENT
        Vector3 currentDirection = _onFoot.Movement.ReadValue<Vector2>();
        _playerMotor.ProcessMovement(currentDirection);
    }
    private void LateUpdate() {
        _playerLook.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void SetInputPerformed(){
        _onFoot.Jump.performed += ctx => _playerMotor.Jump();
        _onFoot.Shoot.performed += ctx => _playerWeapon.Shoot();
        _onFoot.Reload.performed += ctx => _playerWeapon.Reload();

    }
    #region ENABLES
    private void OnEnable() {
        _onFoot.Enable();
    }
    private void OnDisable() {
        _onFoot.Disable();
    }
    #endregion
    #region GETTER SETTERS
    public PlayerInput.OnFootActions GetOnFoot(){
        return _onFoot;
    }
    #endregion
}
