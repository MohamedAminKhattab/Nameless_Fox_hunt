using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour,IExecutable
{
    [SerializeField] Canvas manimenu;
    [SerializeField] Canvas LevelSelection;

    public void Execute()
    {
        manimenu.gameObject.SetActive(false);
        LevelSelection.gameObject.SetActive(true);
    }
}
