using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Camera _cam;
    public Camera Cam { get { return _cam; } }
    private float _xRotation = 0f;
    [SerializeField] private Vector2 _sensivity = new Vector2(30f,30f);

    private void Awake() {
        _cam = GetComponentInChildren<Camera>();
    }


    public void ProcessLook(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;
        //rotate in y axis
        _xRotation -= (mouseY * Time.deltaTime) * _sensivity.y;
        _xRotation = Mathf.Clamp(_xRotation,-80f,+80f);
        _cam.transform.localRotation = Quaternion.Euler(_xRotation,0,0);
        //rotate in x axis
        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * _sensivity.x);
    }
}
