using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsClose_Btn : MonoBehaviour,IExecutable
{

    [SerializeField] GameObject current;
    [SerializeField] GameObject previous;

    public void Execute()
    {
        previous.SetActive(true);
        current.SetActive(false);
    }
}
