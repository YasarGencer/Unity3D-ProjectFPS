using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _isGrounded = false;
    [SerializeField] private float _speed = 5f, _gravity = -9.8f, _maxPull = -2f, _jumpForce = 3f;
    void Start(){
        _controller = GetComponent<CharacterController>();
    }

    void Update(){
        _isGrounded = _controller.isGrounded;
    }
    public void ProcessMovement(Vector2 input){
        Walk(input); Gravity();
    }
    void Walk(Vector2 input){
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        _controller.Move(transform.TransformDirection(moveDir) * _speed * Time.deltaTime);
    }
    void Gravity(){
        //add gravity
        _playerVelocity.y += _gravity * Time.deltaTime;
        //harden the gravity on fall
        if(_playerVelocity.y < 0)
            _playerVelocity.y += _gravity * Time.deltaTime;
        //limit gravity
        if(_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = _maxPull;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    public void Jump(){
        if(_isGrounded)
            _playerVelocity.y = Mathf.Sqrt(_jumpForce * -3f * _gravity);
    }
}