using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager Instance;
    private PlayerWeapon weapon = null;

    //WEAPONS
    public PlayerWeaponTestInstance test;

    private void Awake() {
        Instance = this;
        //test = new PlayerWeaponTestInstance();
        //Equip(test);
    }    
    public void Equip(PlayerWeapon weapon){
        if(this.weapon != null){
            this.Drop();
        }
        this.weapon = weapon;
        if(this.weapon != null){
            this.weapon.Equip();
        }
    }
    public void Shoot(){
        if(weapon != null)
            weapon.Shoot();
    }
    public void Reload(){
        if(weapon != null)
            weapon.Reload();
    }
    public void Drop(){
        if(weapon != null)
            weapon.Drop();
    }
}
