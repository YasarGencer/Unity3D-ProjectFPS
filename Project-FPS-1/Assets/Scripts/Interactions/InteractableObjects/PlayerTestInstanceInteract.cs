using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestInstanceInteract : Interactable
{
    protected override void Interact(){
        PlayerWeaponManager.Instance.Equip(new PlayerWeaponTestInstance());
    }
}