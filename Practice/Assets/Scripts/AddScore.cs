using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    // Start is called before the first frame update
    public IntData scoreValue;

    private void OnTriggerEnter(Collider other)
    {
        scoreValue.value++;
    }
}
