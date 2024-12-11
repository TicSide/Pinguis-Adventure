using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float yOffset = 0f;
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x+6, target.position.y + yOffset, -10f);
        }
    }
}