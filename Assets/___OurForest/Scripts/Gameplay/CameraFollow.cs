using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target { get => target; set => target = value; }
    [SerializeField]
    Transform target;
    [Range(1f, 40f)]
    [SerializeField]
    float laziness = 10f;
    [SerializeField]
    Vector3 offset;
    Vector3 desiredPosition;

    private static CameraFollow instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (target)
        {
            desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1 / laziness);
            transform.LookAt(target);
        }
    }
}