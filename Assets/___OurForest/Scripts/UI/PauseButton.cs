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
        gameUI.gameObject.SetActive(true);
        pausemenu.gameObject.SetActive(false);
    }
    public void Execute()
    {
        gameUI.gameObject.SetActive(false);
        pausemenu.gameObject.SetActive(true);
        gamepause.state = true;
        Time.timeScale = 1.0f;
    }

}