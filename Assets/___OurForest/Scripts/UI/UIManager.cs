using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum UIStates
{
    InMenu,
    InLevelSelection,
    InSettingsMenu,
    InStoryBoard,
    InFullscreenVideo,
    InTutorial,
    InGamePlay,
    InPauseMenu,
    InWinGame,
    InLoseGame,
    InInventory
};
public class UIManager : MonoBehaviour
{

    [Header("States")]
    [SerializeField] UIStates state;
    [Header("StateBooleans")]
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] BoolSO gamePaused;
    [SerializeField] BoolSO toLevelSelection;
    [SerializeField] BoolSO togameplay;
    [SerializeField] BoolSO tutorialstarted;
    [SerializeField] BoolSO tutorialended;
    [SerializeField] BoolSO IntroStarted;
    [SerializeField] BoolSO IntroEnded;

    [Header("Panels")]
    [SerializeField] Canvas mainmenu;
    [SerializeField] Canvas clearCanvas;
    [SerializeField] Canvas lostCanvas;
    [SerializeField] Canvas gameUI;
    [SerializeField] Canvas IntroFullScreen;
    [SerializeField] Canvas pausemenu;
    [SerializeField] Canvas settingsMenu;
    [SerializeField] Canvas levelSelection;
    [SerializeField] Canvas storyBoard;
    [SerializeField] Canvas inventory;
    [SerializeField] Canvas tutorial;
    [Header("SelectedLevel")]
    [SerializeField] IntegerSO selectedLevel;
    private static UIManager instance;

    public UIStates State { get => state; set => state = value; }

    public void SETUILevelSelection()
    {
        state = UIStates.InLevelSelection;
    } 
    public void SETUIMainMenu()
    {
        state = UIStates.InMenu;
    } 
    public void SETUISettings()
    {
        state = UIStates.InSettingsMenu;
    }
    public void SETUITutorial()
    {
        state = UIStates.InTutorial;
    }  
    public void SETUIStoryBoard()
    {
        state = UIStates.InStoryBoard;
    }  
    public void SETUIFullscreenvideo()
    {
        state = UIStates.InFullscreenVideo;
    }  
    public void SETUIGameplay()
    {
        state = UIStates.InGamePlay;
    }   
    public void SETUIPauseMenu()
    {
        state = UIStates.InPauseMenu;
    }   
    public void SETUILoseGame()
    {
        state = UIStates.InLoseGame;
    }   
    public void SETUIWinGame()
    {
        state = UIStates.InWinGame;
    }
    public void SETUIInventory()
    {
        state = UIStates.InInventory;
    }

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
        IntroEnded.state = false;
        IntroStarted.state = false;
    }
    void Start()
    {
        SetUIByState();
    }

    //public void SetUI()
    //{
    //    if (SceneManager.GetSceneByName($"Level {selectedLevel.value}").isLoaded)
    //    {
    //        togameplay.state = true;
    //        if (togameplay.state == true)
    //        {
    //            levelSelection.gameObject.SetActive(false);
    //            lostCanvas.gameObject.SetActive(false);
    //            clearCanvas.gameObject.SetActive(false);
    //            mainmenu.gameObject.SetActive(false);
    //            settingsMenu.gameObject.SetActive(false);
    //            pausemenu.gameObject.SetActive(false);
    //            storyBoard.gameObject.SetActive(false);
    //            gameUI.gameObject.SetActive(true);
    //            inventory.gameObject.SetActive(false);
    //            tutorial.gameObject.SetActive(false);
    //            IntroFullScreen.gameObject.SetActive(false);
    //        }
    //    }
    //    else if (SceneManager.GetActiveScene().name == "MainUI")
    //    {
    //        if (toLevelSelection.state == true && tutorialstarted.state == false)
    //        {
    //            levelSelection.gameObject.SetActive(true);
    //            lostCanvas.gameObject.SetActive(false);
    //            clearCanvas.gameObject.SetActive(false);
    //            mainmenu.gameObject.SetActive(false);
    //            settingsMenu.gameObject.SetActive(false);
    //            pausemenu.gameObject.SetActive(false);
    //            storyBoard.gameObject.SetActive(false);
    //            gameUI.gameObject.SetActive(false);
    //            inventory.gameObject.SetActive(false);
    //            tutorial.gameObject.SetActive(false);
    //            IntroFullScreen.gameObject.SetActive(false);
    //        }
    //        else if(togameplay.state==false&&tutorialstarted.state==false)
    //        {
    //            mainmenu.gameObject.SetActive(true);
    //            levelSelection.gameObject.SetActive(false);
    //            lostCanvas.gameObject.SetActive(false);
    //            clearCanvas.gameObject.SetActive(false);
    //            settingsMenu.gameObject.SetActive(false);
    //            pausemenu.gameObject.SetActive(false);
    //            storyBoard.gameObject.SetActive(false);
    //            gameUI.gameObject.SetActive(false);
    //            inventory.gameObject.SetActive(false);
    //            tutorial.gameObject.SetActive(false);
    //            IntroFullScreen.gameObject.SetActive(false);
    //        }
    //        else if(tutorialstarted.state==true)
    //        {
    //            mainmenu.gameObject.SetActive(false);
    //            levelSelection.gameObject.SetActive(false);
    //            lostCanvas.gameObject.SetActive(false);
    //            clearCanvas.gameObject.SetActive(false);
    //            settingsMenu.gameObject.SetActive(false);
    //            pausemenu.gameObject.SetActive(false);
    //            storyBoard.gameObject.SetActive(false);
    //            gameUI.gameObject.SetActive(false);
    //            inventory.gameObject.SetActive(false);
    //            tutorial.gameObject.SetActive(true);
    //            IntroFullScreen.gameObject.SetActive(false);
    //        }
    //        else if(tutorialended.state==true)
    //        {
    //            mainmenu.gameObject.SetActive(false);
    //            levelSelection.gameObject.SetActive(false);
    //            lostCanvas.gameObject.SetActive(false);
    //            clearCanvas.gameObject.SetActive(false);
    //            settingsMenu.gameObject.SetActive(true);
    //            pausemenu.gameObject.SetActive(false);
    //            storyBoard.gameObject.SetActive(false);
    //            gameUI.gameObject.SetActive(false);
    //            inventory.gameObject.SetActive(false);
    //            tutorial.gameObject.SetActive(false);
    //            IntroFullScreen.gameObject.SetActive(false);
    //        }
    //    }
    //}
    public void SetUIByState()
    {
        switch (state)
        {
            case UIStates.InMenu:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(true);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InLevelSelection:
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
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InSettingsMenu:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(true);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InStoryBoard:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(true);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InFullscreenVideo:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(true);
                break;
            case UIStates.InTutorial:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(true);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InGamePlay:
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
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InPauseMenu:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(true);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InWinGame:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(true);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InLoseGame:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(true);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(false);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            case UIStates.InInventory:
                levelSelection.gameObject.SetActive(false);
                lostCanvas.gameObject.SetActive(false);
                clearCanvas.gameObject.SetActive(false);
                mainmenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                pausemenu.gameObject.SetActive(false);
                storyBoard.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(false);
                inventory.gameObject.SetActive(true);
                tutorial.gameObject.SetActive(false);
                IntroFullScreen.gameObject.SetActive(false);
                break;
            default:
                break;
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
                    state = UIStates.InPauseMenu;
                    SetUIByState();
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
            state = UIStates.InWinGame;
            SetUIByState();

        }
    }
    public void OnPlayerLost()
    {
        if (gameOver.state == true)
        {
            StartCoroutine(WaitforDead());
            Time.timeScale = 0.0f;
            gamePaused.state = true;
            state = UIStates.InLoseGame;
            SetUIByState();
        }
    }
    IEnumerator WaitforDead()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
