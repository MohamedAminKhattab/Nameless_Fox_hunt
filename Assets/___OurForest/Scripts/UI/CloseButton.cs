using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour, IExecutable
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject Gameui;
    [SerializeField] BoolSO paused;
    public void Execute()
    {
        Time.timeScale = 1.0f;
        paused.state = false;
    }
}