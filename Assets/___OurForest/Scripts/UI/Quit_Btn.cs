using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Btn : MonoBehaviour,IExecutable
{
    [SerializeField] BoolSO toLevelSelection;
    [SerializeField] Canvas current;
    [SerializeField] Canvas levelselection;
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] EventSO quitevent;

    public void Execute()
    {
        SceneManager.UnloadSceneAsync($"Level {selectedLevel.value}");
        Time.timeScale = 1.0f;
        quitevent.Raise();
        current.gameObject.SetActive(false);
        toLevelSelection.state = true;
        levelselection.gameObject.SetActive(true);
    }
}
