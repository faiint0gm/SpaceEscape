using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManagement : MonoBehaviour {

    private bool finnished = false;
    public Text currentTime;
    public Text endTime;
    public Text endTimeLose;
    public  GameObject winPanel;
    public  GameObject losePanel;
  
    string minutes;
    string seconds;

	// Use this for initialization
	void Start () {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
        GameManager.timer = Time.time;
        
    }
	
	// Update is called once per frame
	void Update () {
        /*if (finnished)
            return;*/
        CurrentTime();

    }

    public void CurrentTime()
    {
        float t = Time.time - GameManager.timer;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");
        currentTime.text = minutes + ":" + seconds;
        
    }

    public void Finnish()
    {
        winPanel.SetActive(true);
        finnished = true;
        endTime.text = minutes + ":" + seconds;
        Time.timeScale = 0;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        finnished = true;
        endTimeLose.text = minutes + ":" + seconds;
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
