using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseQuit : MonoBehaviour, IExecutable
{
    [SerializeField] BoolSO tolevelSelection;
    [SerializeField] BoolSO gamepaused;
    [SerializeField] Canvas pause;
    [SerializeField] Canvas levelselection;
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] EventSO quitEvent;
    public void Execute()
    {
        SceneManager.UnloadSceneAsync($"Level {selectedLevel.value}");
        Time.timeScale = 1.0f;
        quitEvent.Raise();
        tolevelSelection.state = true;
    }
}
