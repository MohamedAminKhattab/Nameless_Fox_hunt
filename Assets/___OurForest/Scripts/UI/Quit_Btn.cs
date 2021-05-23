using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Btn : MonoBehaviour,IExecutable
{
    [SerializeField] BoolSO toLevelSelection;
    [SerializeField] Canvas current;
    [SerializeField] Canvas levelselection;

    public void Execute()
    {
        SceneManager.LoadScene("MainUI");
        Time.timeScale = 1.0f;
        current.gameObject.SetActive(false);
        toLevelSelection.state = true;
        levelselection.gameObject.SetActive(true);
    }
}
