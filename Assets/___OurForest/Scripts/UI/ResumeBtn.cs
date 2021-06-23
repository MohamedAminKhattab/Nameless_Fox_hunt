using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour,IExecutable
{
    [SerializeField] Canvas pause;
    [SerializeField] Canvas hud;
    [SerializeField] BoolSO gamepaused;
    public void Execute()
    {
        gamepaused.state = false;
        Time.timeScale = 1.0f;
    }
}
