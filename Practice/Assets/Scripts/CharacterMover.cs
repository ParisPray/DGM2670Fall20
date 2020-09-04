using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
  private CharacterController controller;
  private Vector3 movement;
  public float moveSpeed = 5f, gravity = -9.81f, jumpForce = 10f, rotateSpeed = 30f;
  private float yVar;
  private int jumpCount;
  private void Start()
  {
    controller = GetComponent<CharacterController>();
  }
  private void Update()
  {
    var vInput = Input.GetAxis("Vertical");
    
    movement.Set(moveSpeed*vInput, gravity, 0);
    movement = transform.TransformDirection(movement);
    controller.Move(movement * Time.deltaTime);
    var hInput = Input.GetAxis("Horizontal");
    transform.Rotate(0,hInput,0);
    
    yVar += gravity;

    
    if (controller.isGrounded && movement.y <0)
    {
      yVar = -1f;
    }
    
    if (Input.GetKeyDown(KeyCode.Space))
    {
      yVar += Mathf.Sqrt(jumpForce * gravity);
    }
  }
}
