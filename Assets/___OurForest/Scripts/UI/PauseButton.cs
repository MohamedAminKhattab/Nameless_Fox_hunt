using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour,IExecutable
{
    [SerializeField] BoolSO gamepause;
    [SerializeField] Canvas gameUI;
    [SerializeField] Canvas pausemenu;

    void Start()
    {
        gamepause.state = false;
    }
    public void Execute()
    {
        gamepause.state = true;
        Time.timeScale = 0.0f;
    }

}