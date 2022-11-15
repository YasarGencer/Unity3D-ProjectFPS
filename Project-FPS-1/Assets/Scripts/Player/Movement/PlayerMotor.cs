using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded = false;
    public float speed = 5f, gravity = -9.8f, maxPull = -2f, jumpForce = 3f;
    void Start(){
        controller = GetComponent<CharacterController>();
    }

    void Update(){
        isGrounded = controller.isGrounded;
    }
    public void ProcessMovement(Vector2 input){
        Walk(input); Gravity();
    }
    void Walk(Vector2 input){
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
    }
    void Gravity(){
        Debug.Log(playerVelocity.y);
        //add gravity
        playerVelocity.y += gravity * Time.deltaTime;
        //harden the gravity on fall
        if(playerVelocity.y < 0)
            playerVelocity.y += gravity * Time.deltaTime;
        //limit gravity
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = maxPull;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump(){
        if(isGrounded)
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
    }
}