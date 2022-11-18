using UnityEngine;

public class Rifle : PlayerWeapon
{
    public override bool Shoot() {
        if (base.Shoot()) {
            Debug.Log("SHOOT");
        }
        return true;
    }
    public override void Reload() {
        base.Reload();
    }
}
