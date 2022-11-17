using UnityEngine;

public abstract class PlayerWeapon
{
    private StructWeapon _weapon;
    public StructWeapon Weapon { get => _weapon; set => _weapon = value; }
    private PlayerUI ui;
    public void Equip(StructWeapon weapon){
        ui = GameObject.FindGameObjectWithTag(TagManager.Instance.TagPlayer()).GetComponent<PlayerUI>();
        this._weapon = weapon;
        Debug.Log("Equip = " + _weapon.Name);
    }
    public virtual void Shoot()
    {
        UIElements();
    }
    public abstract void Reload();
    public void Drop(){
        Debug.Log("Drop");
    }
    public void UIElements()
    {
        ui.WeaponUI(_weapon);
    }
}