using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    protected override void Interact(){
        Debug.Log("interact with = " + gameObject.name);
    }
}
