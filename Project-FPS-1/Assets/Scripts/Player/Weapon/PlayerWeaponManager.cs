using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager Instance;
    private PlayerWeapon _playerWeapon = null;
    private StructWeapon _weapon = new StructWeapon();
    private bool _shoot = false;
    public void Weapon(StructWeapon weapon) { _weapon = weapon; }

    private void Awake() {
        Instance = this;
    }
    private void Update() {

        if (_playerWeapon != null && _shoot == true)
            _playerWeapon.Shoot();
    }
    public void Equip(PlayerWeapon weapon) {
        if(this._playerWeapon != null){
            this._playerWeapon.Drop();
        }
        this._playerWeapon = weapon;
        if(this._playerWeapon != null && this._weapon.Name != ""){
            this._playerWeapon.Equip(_weapon);
        }
    }
    public void ShootPerform() {
        _shoot = true;
    }
    public void ShootStart() {
        _shoot = true;
    }
    public void ShootCancel() {
        _shoot = false;
    }
    public void Reload() {
        if(_playerWeapon != null)
            _playerWeapon.Reload();
    }
    public void Drop() {
        if(_playerWeapon != null)
            _playerWeapon.Drop();
        if (_weapon.Name != "")
            _weapon = new StructWeapon();
    }
}
