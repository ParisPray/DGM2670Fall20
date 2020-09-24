using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerping : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vOne, vTwo;
    public float value;

    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.Lerp(vOne, vTwo, value);
        value += 0.1f * Time.deltaTime;
        transform.Translate(direction);
    }
}
