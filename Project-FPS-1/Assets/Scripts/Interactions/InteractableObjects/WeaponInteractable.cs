using Unity.VisualScripting;
using UnityEngine;

public class WeaponInteractable : Interactable {
    [SerializeField] private Weapon _weapon;

    protected override void Interact() {
        //SET SCRIPTABLE OBJECT TO PLAYER WEAPON MANAGER
        PlayerWeaponManager.Instance.Weapon(_weapon.weapon);
        //EQUIP CHOOSEN WEAPON
        switch (_weapon.weapon.Name) {
            case "Stone":
                PlayerWeaponManager.Instance.Equip(new Stone());
                break;
            case "Pistol":
                PlayerWeaponManager.Instance.Equip(new Pistol());
                break;
            case "Rifle":
                PlayerWeaponManager.Instance.Equip(new Rifle());
                break;
        }
        Destroy(gameObject);
    }
    public override void PrompText() {
        string text = "[" + _weapon.weapon.Name + "]\n[" + _weapon.weapon.Description + "]";
        PlayerUI.Instance.SetText(PlayerUI.Instance.GetPrompText(), text);
    }
}