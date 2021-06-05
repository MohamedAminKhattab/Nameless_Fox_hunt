using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] List<GameObject> vfx = new List<GameObject>{};
    [SerializeField] GameObject effectToSpwn;
    
    void Start()
    {
        effectToSpwn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpwanerVFX();
        }
    }
    void SpwanerVFX()
    {
        if (firePoint!=null)
        {
            GameObject vfx;
            vfx = Instantiate(effectToSpwn , firePoint.transform.position, Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z));
            
        }
        else
        {
            Debug.Log("no ammo");
        }
    }
}
