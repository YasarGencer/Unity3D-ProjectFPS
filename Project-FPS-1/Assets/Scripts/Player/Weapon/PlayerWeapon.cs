using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerWeapon
{
    protected StructWeapon _weapon;
    public StructWeapon Weapon { get => _weapon; set => _weapon = value; }
    private PlayerUI _ui;
    private Camera _cam;
    private Animator _gun;
    public void Equip(StructWeapon weapon, Animator gun) {
        _gun = gun;
        if(_cam == null)
            _cam= Camera.main;
        if(_ui == null)
            _ui = GameObject.FindGameObjectWithTag(TagManager.Instance.TagPlayer()).GetComponent<PlayerUI>();
        this._weapon = weapon;
        Debug.Log("Equiped a " + _weapon.Name);
        Reload();
    }
    public virtual bool Shoot() {
        if(_weapon.Ammo > 0 && _weapon.ShootTimer < Time.time) {
            SetShootTime(_weapon.FireRate + Time.time);
            _weapon.Ammo--;
            ShootRay();
            ShootAnim();
            if (this._weapon.Ammo <= 0)
                Reload();
            UIElements();
            return true;    
        }
        return false;
    }
    public virtual void ShootRay() {
        float dist = _weapon.Range;
        //create a ray
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist);
        //get collision info and make it interactable
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, dist))
            Debug.Log(hitInfo.collider.gameObject.tag);
    }
    public virtual void Reload() { 
        if(_weapon.Ammo < _weapon.MagCapasite) {
            _weapon.Ammo = _weapon.MagCapasite;
            _weapon.MagCount--;
            UIElements();
        }
    }
    public void Drop() {
        Debug.Log("Dropped a " + _weapon.Name);
        _ui.WeaponUI(new StructWeapon());
        
    }
    public void UIElements() {
        _ui.WeaponUI(_weapon);
    }
    public void SetShootTime(float time) {
        _weapon.ShootTimer = time;
    }
    public void ShootAnim() {
        if(_gun != null) {
            _gun.SetTrigger("Shoot");
        }
    }
}