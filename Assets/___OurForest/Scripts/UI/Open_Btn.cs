using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Btn : MonoBehaviour,IExecutable
{
    [SerializeField] GameObject current;
    [SerializeField] GameObject next;

    public void Execute()
    {
        next.SetActive(true);
        current.SetActive(false);
    }
}
