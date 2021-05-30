using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Btn : MonoBehaviour, IExecutable
{
    [SerializeField] Canvas lost;
    [SerializeField] Canvas hud;
    [SerializeField] BoolSO gamepaused;
    [SerializeField] IntegerSO selectedLevel;
    public void Execute()
    {
        SceneManager.UnloadSceneAsync($"Level {selectedLevel.value}");
        SceneManager.LoadScene($"Level {selectedLevel.value}",LoadSceneMode.Additive);
        gamepaused.state = false;
        Time.timeScale = 1.0f;
        lost.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
    }
}