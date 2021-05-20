using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResult : MonoBehaviour
{
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] BoolSO gamePaused;
    [SerializeField] Canvas clearCanvas;
    [SerializeField] Canvas lostCanvas;
    [SerializeField] Canvas gameUI;
    void Start()
    {
        gamePaused.state = false;
        clearCanvas.gameObject.SetActive(false);
        lostCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerWon.state == true)
        {
            Time.timeScale = 0.0f;
            gamePaused.state = true;
            clearCanvas.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);

        }
        if (gameOver.state == true)
        {
            Time.timeScale = 0.0f;
            gamePaused.state = true;
            lostCanvas.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);
        }
    }
}
