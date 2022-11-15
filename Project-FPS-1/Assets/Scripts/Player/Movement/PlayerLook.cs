using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [HideInInspector] public Camera cam;
    private float xRotation = 0f;
    public Vector2 sensivity = new Vector2(30f,30f);

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
    }


    public void ProcessLook(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;
        //rotate in y axis
        xRotation -= (mouseY * Time.deltaTime) * sensivity.y;
        xRotation = Mathf.Clamp(xRotation,-80f,+80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        //rotate in x axis
        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * sensivity.x);
    }
}
