using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeMusicVol : MonoBehaviour {

    public AudioMixer mainMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        SetUpSingleton();
    }

    public void SetMusicLvl ()
    {
        mainMixer.SetFloat("musicVol", musicSlider.value);
    }

    public void SetSfxLvl()
    {
        mainMixer.SetFloat("fx", sfxSlider.value);
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
