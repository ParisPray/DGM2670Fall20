using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
  private CharacterController controller;
  private Vector3 movement;
  public float gravity = -9.81f, jumpForce = 10f, rotateSpeed = 30f;
  private float yVar;

  public IntData playerJumpCount;
  private int jumpCount;
  public Vector3Data currentSpawnPoint;
  public floatData moveSpeed, normalSpeed, fastSpeed;
  private void Start()
  {
    moveSpeed = normalSpeed;
    controller = GetComponent<CharacterController>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      moveSpeed = fastSpeed;
    }

    if (Input.GetKeyUp(KeyCode.LeftShift))
    {
      moveSpeed = normalSpeed;
    }
    
    var vInput = Input.GetAxis("Vertical") * moveSpeed.value;

    movement.Set(vInput, yVar, 0);
    movement = transform.TransformDirection(movement);

    controller.Move(movement * Time.deltaTime);
    var hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;

    transform.Rotate(0, hInput, 0);

    yVar += gravity * Time.deltaTime;


    if (controller.isGrounded && movement.y < 0)
    {
      yVar = -1f;
      jumpCount = 0;
    }

    if (Input.GetButtonDown("Jump")&& jumpCount < playerJumpCount.value)
    {
      yVar += jumpForce;
      jumpCount++;
    }
    
  }
}

