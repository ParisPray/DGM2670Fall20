using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterWithStates : MonoBehaviour
{
    private CharacterController controller;
    public CharacterMachineData characterStates;

    private Vector3 movement;
    public float moveSpeed = 3;
    public float gravity = -9.81f;
        
        
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var newInput = Input.GetAxis("Vertical")*moveSpeed;
                
        switch (characterStates.value)
        {
            case CharacterMachineData.characterStates.StandardWalk:
                movement.Set(newInput,gravity,0);
                print("Walk");
                break;
            case CharacterMachineData.characterStates.NoGravityWalk:
                movement.Set(newInput,0,0);
                print("Walk");
                break;
            case CharacterMachineData.characterStates.WallCrawl:
                movement.Set(0,newInput,0);
                print("Crawl");
                break;
            case CharacterMachineData.characterStates.KnockBack:
                print("KnockBack");
                break;
        }

        var newMovement = movement * Time.deltaTime;
        controller.Move(newMovement);
    }
}
