using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    bool hitSomething = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       transform.rotation = Quaternion.LookRotation(rb.velocity);
        StartCoroutine(DestroyArrow());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity);
        if (!hitSomething)
        {   
            transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} arrow script");
        if (collision.collider.tag!= "Arrow")
        {
            hitSomething = true;
            Stick();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} arrow script");
    }
    void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(4.0f);
        if (!hitSomething)
            Destroy(this.gameObject);
    }
}
