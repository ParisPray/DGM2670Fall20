using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;

    public void Instance()
    {
        var location = transform.position;
        var newObj = Instantiate(prefab);
    }
}
  