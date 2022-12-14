using UnityEngine;

public class Pistol : PlayerWeapon
{
    public override bool Shoot() {
        if (base.Shoot()) {
            base.CreateParticle(base.ShootRay(Weapon.Range));
        }
            
        return true;
    }
    public override void Reload() {
        base.Reload();
    }
}