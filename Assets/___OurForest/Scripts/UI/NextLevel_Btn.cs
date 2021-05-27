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
        selectedLevel.value++;
        SceneManager.LoadScene("Integrated GamePlay");
        Time.timeScale = 1.0f;
        clear.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
    }
}
