using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System;

public class TimeLineKeeping : MonoBehaviour
{
  [SerializeField]  List<TimelineAsset> timelines;
  [SerializeField]  PlayableDirector director;
    int index=-1;
   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayNext();
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            PlayPrevious();
    }

    private void PlayNext()
    { 
        if(index<timelines.Count-1)
        director.Play(timelines[++index]);
    }
    private void PlayPrevious()
    {
        if(index>0)
        director.Play(timelines[--index]);

    }
}
