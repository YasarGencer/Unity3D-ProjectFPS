using UnityEngine;

public class WeaponInteractable : Interactable
{
    enum WeaponsEnum{
        PISTOL, RIFLE
    }
    [SerializeField] private WeaponsEnum _weapon;

    protected override void Interact()
    {
        switch (_weapon)
        {
            case WeaponsEnum.PISTOL: PlayerWeaponManager.Instance.Equip(new Pistol()); break;
            case WeaponsEnum.RIFLE: PlayerWeaponManager.Instance.Equip(new Rifle()); break;
        }
    }
}
