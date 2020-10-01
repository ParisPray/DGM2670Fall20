using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody _rBody;
    public float force = 30f;
    private Vector3 forceVector;
    

    public Vector3Data aimVector;
    
    // Start is called before the first frame update
    void Start()
    {
        var aimDir = aimVector.value; 
        forceVector = new Vector3(force, force, force);
        var forceDirection = multVector(aimDir, forceVector);
        _rBody = GetComponent<Rigidbody>();
       // var forceDirection = new Vector3(0, 0, force);
        _rBody.AddRelativeForce(forceDirection);
        print(forceDirection);
    }
    
    

    private Vector3 multVector (Vector3 one, Vector3 two)
    {
        var result = new Vector3();
        result = Vector3.Scale(one, two); 
        return result;
        
    } 

   
}
