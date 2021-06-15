using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] Panels;
    string[] TextsToShow = { "We can view Greedy hunter intruders’ waves here",
    "To defend our forest, we need to be prepared for greedy hunters by crafting traps and weapons.  For that, we need to gather resources from the forest by walking near them or sending the fox to collect them for you.." ,
            "We now have enough resources to craft! by clicking this icon you can see your inventory",
            " you need to make sure that the resources you have are enough to craft the item you need..",
            "Before the hunters come, you can place traps anywhere on the map by clicking on the location of your choice then clicking on the trap button.",
            "another way to fight hunters is by using weapons.. Click on the hunter you need to kill then the weapon icon",
            "Your fox friend can help you in your mission, He can help you pickup resources and lure enemies.. just click on the resource or enemy,then, click the fox button",
            "If you want the fox to abort his position and come back to you, click on the fox icon again!",
            "Oh no! The hunters are here!"
    };
    [SerializeField] private TMP_Text textHolder;
    [SerializeField] BoolSO tutorialstarted;
    [SerializeField] BoolSO tutorialended;
    [SerializeField] EventSO OnTutorialEnded;
    [SerializeField]private int index=0;
    private void Start()
    {
        tutorialended.state = false;
        index = 0;
        Restarttut();
    }
    public void Restarttut()
    {
        index = 0;
        Panels[Panels.Length-1].SetActive(false);
        Panels[index].SetActive(true);
        textHolder.text = TextsToShow[index];
    }
    public void ShowNext()
    {
        if (index < Panels.Length) // panels num must be equal to strings num
        {
            if (index > 0)
                Panels[index - 1].SetActive(false);
            Panels[index].SetActive(true);
        textHolder.text = TextsToShow[index];
        index++;
        }
        else
        {
            tutorialstarted.state = false;
            tutorialended.state = true;
            OnTutorialEnded.Raise();
        }
        // else Finish the Scene 
    }
}