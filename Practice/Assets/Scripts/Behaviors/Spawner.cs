using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public GameObject spawnObject;
 
    void Update ()
    {
        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds (Random.Range (1, 600));
        Instantiate(spawnObject);
        Debug.Log("Object Spawned");
    }
}
