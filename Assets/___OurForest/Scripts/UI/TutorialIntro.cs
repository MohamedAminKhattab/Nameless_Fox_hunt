using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialIntro : MonoBehaviour
{
    [SerializeField] Canvas VideoIntro;
    [SerializeField] EventSO introEnded;
    private void LateUpdate()
    {
        StartCoroutine(CheckVideo());
    }

   IEnumerator CheckVideo()
    {
        yield return new WaitForSeconds(2.0f);
        if (!VideoIntro.GetComponentInChildren<VideoPlayer>().isPlaying)
        {
            introEnded.Raise();
        }
    }
}
