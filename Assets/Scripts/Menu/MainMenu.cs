using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public SoundContainer soundPlayer;

    private void Awake()
    {
        soundPlayer.PlayMusicLoop(0);
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        GameManager.isLose = false;
        GameManager.isWin = false;
    }

    public void QuitGame ()
    {
        Debug.Log("Wylaczyles gre");
        Application.Quit();
    }

    
}
