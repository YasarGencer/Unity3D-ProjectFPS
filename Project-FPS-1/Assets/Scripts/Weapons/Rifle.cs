using UnityEngine;

public class Rifle : PlayerWeapon
{
    public override void Shoot()
    {
        Debug.Log("Rifle Shoot");
    }
    public override void Reload()
    {
        Debug.Log("Rifle Reload");
    }
}
