using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBtn : MonoBehaviour,IExecutable
{
    [SerializeField] Canvas settings;
    [SerializeField] Canvas storyBoard;

    public void Execute()
    {
        settings.gameObject.SetActive(false);
        storyBoard.gameObject.SetActive(true);
    }
}
