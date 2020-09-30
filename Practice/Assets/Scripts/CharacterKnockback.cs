using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKnockback : MonoBehaviour
{
    public CharacterController controller;

    public Vector3 knockBackVector;

    public float knockBackForce = 50f;
    
    private float countDown;
    
    
  private IEnumerator Start(){
  while (knockBackForce > 0){
  knockBackVector.x = knockBackForce*Time.deltaTime;
  controller.Move(knockBackVector);
  knockBackForce -= 0.1f;}
  }
}
  

