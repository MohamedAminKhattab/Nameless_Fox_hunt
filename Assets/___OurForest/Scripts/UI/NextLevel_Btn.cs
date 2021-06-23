using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Btn : MonoBehaviour, IExecutable
{

    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] Canvas clear;
    [SerializeField] Canvas hud;

    public void Execute()
    {
        SceneManager.UnloadSceneAsync($"Level {selectedLevel.value}");
        selectedLevel.value++;
        SceneManager.LoadScene($"Level {selectedLevel.value}", LoadSceneMode.Additive);
        Time.timeScale = 1.0f;
    }
}