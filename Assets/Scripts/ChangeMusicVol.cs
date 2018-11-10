using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeMusicVol : MonoBehaviour {

    public AudioMixer mainMixer;

    private void Awake()
    {
        SetUpSingleton();
    }

    public void SetMusicLvl (float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
    }

    public void ClearVolume()
    {
        mainMixer.ClearFloat("musicVol");
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

  
}
