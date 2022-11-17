using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [HideInInspector] public Camera Cam;
    private float _xRotation = 0f;
    [SerializeField] private Vector2 _sensivity = new Vector2(30f,30f);

    private void Awake() {
        Cam = GetComponentInChildren<Camera>();
    }


    public void ProcessLook(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;
        //rotate in y axis
        _xRotation -= (mouseY * Time.deltaTime) * _sensivity.y;
        _xRotation = Mathf.Clamp(_xRotation,-80f,+80f);
        Cam.transform.localRotation = Quaternion.Euler(_xRotation,0,0);
        //rotate in x axis
        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * _sensivity.x);
    }
}
