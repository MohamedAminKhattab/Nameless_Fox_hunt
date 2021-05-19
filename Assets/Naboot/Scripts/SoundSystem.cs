using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioClip[] EnemyStatements;
    [SerializeField] AudioClip[] FoxStatements;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayEnemySound(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.chasingFox:
                source.clip = EnemyStatements[0];
                if(!source.isPlaying)
                source.Play();
                break;
            case EnemyState.goingToHouse:
                source.clip = EnemyStatements[1];
                if(!source.isPlaying)
                source.Play();
                break;
            case EnemyState.shooting:
                source.clip = EnemyStatements[2];
                if (!source.isPlaying)
                    source.Play();
                break;

        }
    }
}
