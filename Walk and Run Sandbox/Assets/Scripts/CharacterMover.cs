using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 movement;

    public float gravity = -9.81f, rotateSpeed = 30f;

    private float yVar;

    public floatData moveSpeed, normalSpeed, fastSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
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
        
    }
}
