using UnityEngine;

public class Pistol : PlayerWeapon
{
    public override void Shoot()
    {
        Debug.Log("Pistol Shoot");
    }
    public override void Reload()
    {
        Debug.Log("Pistol Reload");
    }
}

