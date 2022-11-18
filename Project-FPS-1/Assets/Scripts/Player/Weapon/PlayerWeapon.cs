using UnityEngine;

public abstract class PlayerWeapon
{
    protected StructWeapon _weapon;
    public StructWeapon Weapon { get => _weapon; set => _weapon = value; }
    private PlayerUI ui;
    public void Equip(StructWeapon weapon) {
        if(ui == null)
            ui = GameObject.FindGameObjectWithTag(TagManager.Instance.TagPlayer()).GetComponent<PlayerUI>();
        this._weapon = weapon;
        Debug.Log("Equiped a " + _weapon.Name);
        Reload();
    }
    public virtual bool Shoot() {
        if(_weapon.Ammo > 0 && _weapon.ShootTimer < Time.time) {
            _weapon.ShootTimer = _weapon.FireRate + Time.time;
            _weapon.Ammo--;

            if (this._weapon.Ammo <= 0)
                Reload();
            UIElements();
            return true;    
        }
        return false;
    }
    public virtual void Reload() { 
        if(_weapon.Ammo < _weapon.MagCapasite) {
            _weapon.Ammo = _weapon.MagCapasite;
            _weapon.MagCapasite--;
            UIElements();
        }
    }
    public void Drop() {
        Debug.Log("Dropped a " + _weapon.Name);
        ui.WeaponUI(new StructWeapon());
        
    }
    public void UIElements() {
        ui.WeaponUI(_weapon);
    }
}