using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StoryBoardSystem : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    [SerializeField] Sprite play;
    [SerializeField] Sprite pause;
    [SerializeField] Image playorpause;
    [SerializeField] Button tostart;
    [SerializeField] Button toend;
    private void Start()
    {
        playorpause.sprite = play;
        player.prepareCompleted += OnVideoPrepared;
        player.Prepare();
    }

    private void OnVideoPrepared(VideoPlayer videoPlayer)
    {
        player.Play();
        playorpause.sprite = pause;
    }
    public void playorpausevid()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            playorpause.sprite = pause;
        }
        else if (player.isPaused==false)
        {
            player.Pause();
            playorpause.sprite = play;
        }
    }
    public void backframe()
    {
        player.frame-=10;
        player.Play();
        playorpause.sprite = pause;
    }
    public void forwardFrame()
    {
        player.frame+=10;
        player.Play();
        playorpause.sprite = pause;
    }
    private void OnDisable()
    {
        player.frame = 0;
    }
}
