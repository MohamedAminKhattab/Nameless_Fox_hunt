using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firt : MonoBehaviour
{
    public float speed, FireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}
