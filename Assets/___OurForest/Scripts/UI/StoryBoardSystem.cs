using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoardSystem : MonoBehaviour
{
    [SerializeField] Image board;
    [SerializeField] Button next;
    [SerializeField] Button previous;
    [SerializeField] Sprite[] storyboards;
    int currentBoard;
    void Start()
    {
        board = GetComponent<Image>();
        currentBoard = 0;
        board.sprite = storyboards[currentBoard];
    }
    private void Update()
    {
        if(currentBoard==0)
        {
            previous.interactable = false;
            next.interactable = true;
        }
        else if(currentBoard>0&&currentBoard<storyboards.Length-1)
        {
            previous.interactable = true;
            next.interactable = true;
        }
        else if(currentBoard==storyboards.Length-1)
        {
            previous.interactable = true;
            next.interactable = false;
        }
    }
    public void Increment()
    {
        currentBoard++;
        board.sprite = storyboards[currentBoard];
    }
    public void Decrement()
    {
        currentBoard--;
        board.sprite = storyboards[currentBoard];
    }
}
