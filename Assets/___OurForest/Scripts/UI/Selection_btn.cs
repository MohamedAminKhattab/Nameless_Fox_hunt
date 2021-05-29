using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection_btn : MonoBehaviour, IExecutable
{
    [SerializeField] IntegerSO selectedlevel;
    [SerializeField] BoolSO togameplay;
    public void selectlevel(int level)
    {
        selectedlevel.value = level;
    }
    public void Execute()
    {
        togameplay.state = true;
        //SceneManager.LoadScene("Integrated GamePlay");
        SceneManager.LoadScene($"Level {selectedlevel.value}", LoadSceneMode.Additive);
    }
}
