using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour {

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Start()
    {
        musicSource.loop = true;
        musicSource.outputAudioMixerGroup = GameManager.instance.musicGroup;
        sfxSource.outputAudioMixerGroup = GameManager.instance.sfxGroup;
    }

    AudioClip SetClip(SoundType type, int clipNumber)
    {
        if (type == SoundType.Music)
            return musicClips[clipNumber];
        else if (type == SoundType.SFX)
            return sfxClips[clipNumber];
        else return null;
    }

    public void PlaySound(int clipNumber)
    {
        sfxSource.PlayOneShot(SetClip(SoundType.SFX,clipNumber));
    }

    public void PlayMusicLoop(int clipNumber)
    {
        AudioClip clip = SetClip(SoundType.Music, clipNumber);
        musicSource.clip = clip;
        musicSource.Play();
    }
}

enum SoundType
{
    Music = 1,
    SFX = 2
}