using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialIntro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] Canvas VideoIntro;
    [SerializeField] EventSO introEnded;
    private void Update()
    {
        if (selectedLevel.value == 0)
        {
            VideoIntro.gameObject.SetActive(true);
        }
        if (!VideoIntro.GetComponentInChildren<VideoPlayer>().isPlaying)
        {
            introEnded.Raise();
            VideoIntro.gameObject.SetActive(false);
        }
    }
    public void PlayVideo()
    {
       
    }
}
