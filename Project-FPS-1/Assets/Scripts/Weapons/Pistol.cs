using UnityEngine;

public class Pistol : PlayerWeapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Pistol Shoot");
    }
    public override void Reload()
    {
        Debug.Log("Pistol Reload");
    }
}

