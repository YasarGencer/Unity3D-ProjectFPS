using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager Instance;
    private PlayerWeapon _weapon = null;

    //WEAPONS
    public PlayerWeaponTestInstance test;

    private void Awake() {
        Instance = this;
        //test = new PlayerWeaponTestInstance();
        //Equip(test);
    }    
    public void Equip(PlayerWeapon weapon){
        if(this._weapon != null){
            this.Drop();
        }
        this._weapon = weapon;
        if(this._weapon != null){
            this._weapon.Equip();
        }
    }
    public void Shoot(){
        if(_weapon != null)
            _weapon.Shoot();
    }
    public void Reload(){
        if(_weapon != null)
            _weapon.Reload();
    }
    public void Drop(){
        if(_weapon != null)
            _weapon.Drop();
    }
}
