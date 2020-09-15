using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;

    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        var location = transform.position;
        var RotationDirection = new Vector3(0f, 45f, 0f);
        Instantiate(prefab, location, Quaternion.Euler(RotationDirection));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}