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
    public void Execute()
    {
        pause.gameObject.SetActive(false);
        levelselection.gameObject.SetActive(true);
        tolevelSelection.state = true;
        gamepaused.state = false;
        SceneManager.LoadScene("MainUI");
        Time.timeScale = 1.0f;
    }
}
