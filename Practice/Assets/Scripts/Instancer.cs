using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;

    public Vector3Data rotationDirection;
    // Start is called before the first frame update
    public void Instance()
    {
        var location = transform.position;
        Instantiate(prefab, location, Quaternion.Euler(rotationDirection.value));
        print(rotationDirection.value);
        print(transform.eulerAngles);
    }
}
  