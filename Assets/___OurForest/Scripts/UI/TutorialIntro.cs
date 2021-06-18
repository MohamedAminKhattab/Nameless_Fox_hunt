using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialIntro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] Canvas VideoIntro;
    [SerializeField] Canvas hud;
    [SerializeField] EventSO introEnded;
    private void Update()
    {
        if (!VideoIntro.GetComponentInChildren<VideoPlayer>().isPlaying)
        {
            introEnded.Raise();
            VideoIntro.gameObject.SetActive(false);
        }
    }
    public void PlayVideo()
    {
        Debug.Log("VideoStarted");
        if (selectedLevel.value == 0)
        {
            VideoIntro.gameObject.SetActive(true);
            VideoIntro.GetComponentInChildren<VideoPlayer>().Play();
            hud.gameObject.SetActive(false);
        }
    }
}
