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
    Vector3 cameraDirection;
    float cameraDistance;
    Vector2 cameraMinMax = new Vector2(0.5f, 5f);
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
    void Start()
    {
        //cameraDirection = transform.localPosition.normalized;
        //cameraDistance = cameraMinMax.y;

    }
    void FixedUpdate()
    {
        if (target)
        {
            desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition,1);
            transform.LookAt(target);
        }

    
    }
    void CheckCameraOcclusionAndCollision(Transform cam)
    {
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection* cameraMinMax.y);
        RaycastHit hit;
        if(Physics.Linecast(transform.position,desiredCameraPosition,out hit))
            cameraDistance = Mathf.Clamp(hit.distance, cameraMinMax.x, cameraMinMax.y);
      
        else
          cameraDistance = cameraMinMax.y;
        
        transform.localPosition=cameraDirection*cameraDistance;
    }
}