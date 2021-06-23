using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryButton : MonoBehaviour, IExecutable
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject Gameui;
    [SerializeField] BoolSO paused;
    private void Start()
    {
        paused.state = false;
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                Application.Quit();
                //  SceneManager.LoadScene($"LevelSelection");
            }
        }
    }
    public void Execute()
    {
        paused.state = true;
        Time.timeScale = 0.0f;
    }
}
