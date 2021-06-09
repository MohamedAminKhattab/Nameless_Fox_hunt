using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDisolver : MonoBehaviour
{
    [SerializeField]
    HealthSO playerHealth;
    Renderer rend;
    float value = 0;
    float disolve = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.dead)
        {
            if (value < 1)
            {
                value += Time.deltaTime * disolve;
                rend.material.SetFloat("_Disolver", value);
            }
        }
    }
}
