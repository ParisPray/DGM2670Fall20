﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
  private CharacterController controller;
    private Vector3 movement;

    public float rotateSpeed = 30f, gravity = -9.81f, jumpForce = 10f;
    private float yVar;

    public floatData normalSpeed, fastSpeed;
    private floatData moveSpeed;
    private bool canMove = true;
    
    public IntData playerJumpCount;
    private int jumpCount;

    public Animator pigAnimator;
    public bool isJumping;
    public bool isRunning;
    public bool isIdle;
    

    private void Start() 
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        StartCoroutine(Move());
    }

    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private IEnumerator Move()
    {
        canMove = true;
        pigAnimator.SetBool("isRunning", true);
        while (canMove)
        {
            
            yield return wffu;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                pigAnimator.SetBool("isIdle", false);
                pigAnimator.SetBool("isIdle", true);
                moveSpeed = fastSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = normalSpeed;
                pigAnimator.SetBool("isIdle", true);
                pigAnimator.SetBool("isIdle", false);

            }
        
            var vInput = Input.GetAxis("Vertical")*moveSpeed.value;
            
            movement.Set(vInput,yVar,0);
        
            var hInput = Input.GetAxis("Horizontal")*Time.deltaTime*rotateSpeed;
            transform.Rotate(0,hInput,0);

            yVar += gravity*Time.deltaTime;

            if (controller.isGrounded && movement.y < 0)
            {
                pigAnimator.SetBool("isJumping", false);
                pigAnimator.SetBool("isIdle", true);
                pigAnimator.SetBool("isRunning", true);
                yVar = -1f;
                jumpCount = 0;
               

            }

            if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
            {
                pigAnimator.SetBool("isIdle", false);
                pigAnimator.SetBool("isJumping", true);
                yVar = jumpForce;
                jumpCount++;
                
            }
        
            movement = transform.TransformDirection(movement);
            controller.Move((movement) * Time.deltaTime);
        }
    }
    private IEnumerator KnockBack (ControllerColliderHit hit, Rigidbody body)
    {
        canMove = false;
        var i = 2f;
       
        movement = -hit.moveDirection;
        movement.y = -1;
        while (i > 0)
        {
            yield return wffu;
            i -= 0.1f;
            controller.Move((movement) * Time.deltaTime);
            
            var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            var forces = pushDir * pushPower;
            body.AddForce(forces);
        }
        movement = Vector3.zero;
        StartCoroutine(Move());
    }
    
    public float pushPower = 10.0f;
    private CharacterController characterController;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
        {
            return;
        }
    
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
       
        StartCoroutine(KnockBack(hit, body));
    }
}

