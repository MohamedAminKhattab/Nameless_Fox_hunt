using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit_Btn : MonoBehaviour, IExecutable
{
    public void Execute()
    {
        Application.Quit();
    }
}
