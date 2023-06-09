using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    Transform target;
    Transform rotTarget;
    Vector3 lastPos;

    float sensitivity = 0.25f;

    // Awake()は、Stat()より前にcallされます
    void Awake()
    {
        rotTarget = transform.parent;
        target = rotTarget.transform.parent;
    }

    void Update()
    {
        transform.LookAt(target);
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        Orbit();　//軌道
    }

    void Orbit() 
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPos;
            float angleY = -delta.y * sensitivity;
            float angleX = delta.x * sensitivity;
            //X AXIS
            Vector3 angles = rotTarget.transform.eulerAngles;
            angles.x += angleY;
            angles.x = ClampAngle(angles.x, -85f, 85f);
            rotTarget.transform.eulerAngles = angles;

            //Y AXIS
            target.RotateAround(target.position, Vector3.up, angleX);
            lastPos = Input.mousePosition;
        }
    }

    // playfieldをmouse dragで真上に回転させた場合、shuffleする為
    // このmethodでshuffleを防止
    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    
    }
}
