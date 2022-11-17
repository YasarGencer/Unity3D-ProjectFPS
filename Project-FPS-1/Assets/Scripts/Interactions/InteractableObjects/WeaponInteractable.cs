using UnityEngine;

public class WeaponInteractable : Interactable
{
    [SerializeField] private Weapon _weapon;

    protected override void Interact()
    {
        //SET SCRIPTABLE OBJECT TO PLAYER WEAPON MANAGER
        PlayerWeaponManager.Instance.Weapon(_weapon.weapon);
        //EQUIP CHOOSEN WEAPON
        switch (_weapon.weapon.Name)
        {
            case "Pistol":
                PlayerWeaponManager.Instance.Equip(new Pistol());
                break;
            case "Rifle":
                PlayerWeaponManager.Instance.Equip(new Rifle());
                break;
        }
    }
}
