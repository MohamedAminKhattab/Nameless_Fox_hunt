using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("StateBooleans")]
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] BoolSO gamePaused;
    [SerializeField] BoolSO toLevelSelection;
    [SerializeField] BoolSO togameplay;
    [SerializeField] BoolSO tutorialstarted;
    [SerializeField] BoolSO tutorialended;
    [Header("Panels")]
    [SerializeField] Canvas mainmenu;
    [SerializeField] Canvas clearCanvas;
    [SerializeField] Canvas lostCanvas;
    [SerializeField] Canvas gameUI;
    [SerializeField] Canvas pausemenu;
    [SerializeField] Canvas settingsMenu;
    [SerializeField] Canvas levelSelection;
    [SerializeField] Canvas storyBoard;
    [SerializeField] Canvas inventory;
    [SerializeField] Canvas tutorial;
    [Header("SelectedLevel")]
    [SerializeField] IntegerSO selectedLevel;
    private static UIManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void OnDisable()
    {
        gamePaused.state = false;
        playerWon.state = false;
        gameOver.state = false;
        togameplay.state = false;
        toLevelSelection.state = false;
        tutorialended.state = false;
        tutorialstarted.state = false;
    }
    void Start()
    {
        SetUI();
    }

    public void SetUI()
    {
        if (SceneManager.GetSceneByName($"Level {selectedLevel.value}").isLoaded)
        {
            togameplay.state = true;
            if (togameplay.state == true)
            {
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(true);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "MainUI")
        {
            if (toLevelSelection.state == true && tutorialstarted.state == false)
            {
                levelSelection.gameObject.SetActive(true);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
            }
            else if(togameplay.state==false&&tutorialstarted.state==false)
            {
                mainmenu.gameObject.SetActive(true);
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
            }
            else if(tutorialstarted.state==true)
            {
                mainmenu.gameObject.SetActive(false);
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(true);
            }
            else if(tutorialended.state==true)
            {
                mainmenu.gameObject.SetActive(false);
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(true);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                if (SceneManager.GetActiveScene().name == "MainUI" && mainmenu.gameObject.activeInHierarchy == true)
                {
                    Application.Quit();
                }
                if (SceneManager.GetActiveScene().name.Contains("Level"))
                {
                    gameUI.gameObject.SetActive(false);
                    pausemenu.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                    gamePaused.state = true;
                }
            }
        }
    }
    public void OnPlayerWon()
    {
        if (playerWon.state == true)
        {
            StartCoroutine(WaitforDead());
            Time.timeScale = 0.0f;
            gamePaused.state = true;
            clearCanvas.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);

        }
    }
    public void OnPlayerLost()
    {
        if (gameOver.state == true)
        {
            StartCoroutine(WaitforDead());
            Time.timeScale = 0.0f;
            gamePaused.state = true;
            lostCanvas.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);
        }
    }
    IEnumerator WaitforDead()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
