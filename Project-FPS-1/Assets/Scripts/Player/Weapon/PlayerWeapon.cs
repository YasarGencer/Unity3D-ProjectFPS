using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon
{
    public void Equip(){
        Debug.Log("Equip");
    }
    public abstract void Shoot();
    public abstract void Reload();
    public void Drop(){
        Debug.Log("Drop");
    }
}
