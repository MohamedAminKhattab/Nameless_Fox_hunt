using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [Range(1f, 40f)]
    [SerializeField]
    float laziness = 10f;
    [SerializeField]
    Vector3 offset;
    Vector3 desiredPosition;

    void FixedUpdate()
    {

        desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 1 / laziness);

        transform.LookAt(target);

    }
}
