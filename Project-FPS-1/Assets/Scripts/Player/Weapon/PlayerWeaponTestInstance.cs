using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTestInstance : PlayerWeapon
{
    public override void Shoot(){
        Debug.Log("Shoot");
    }

    public override void Reload(){
        Debug.Log("Reload");
    }
}