using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetter : MonoBehaviour {

    public SoundContainer soundPlayer;

    private void Start()
    {
        soundPlayer.PlayMusicLoop(0);
    }
}
