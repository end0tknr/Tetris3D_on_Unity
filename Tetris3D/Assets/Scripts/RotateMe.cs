using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,speed*Time.deltaTime);
    }
}
