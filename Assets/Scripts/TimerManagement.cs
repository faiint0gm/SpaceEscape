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
    public GameObject gameManagerPrefab;

    public CameraController mainCamController;
    string minutes;
    string seconds;

    int thisSceneNumber;
	// Use this for initialization
	void Start () {

        if (GameManager.instance == null)
            Instantiate(gameManagerPrefab);

        GameManager.isWin = false;
        GameManager.isDead = false;
        GameManager.isLose = false;

        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
        GameManager.timer = Time.time;

        StartCoroutine(NegativeBlinker.instance.BlinkTimes(3));
    }
	
	// Update is called once per frame
	void Update () {
        /*if (finnished)
            return;*/
        CurrentTime();
        if (GameManager.isWin)
        {
            Finnish();
        }
        if (GameManager.isLose)
        {
            Lose();
        }
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
        mainCamController.enabled = false;
        mainCamController.target.gameObject.SetActive(false);

        losePanel.SetActive(true);
        finnished = true;
        endTimeLose.text = minutes + ":" + seconds;
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.isWin = false;
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        thisSceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisSceneNumber);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        while(GameManager.isLose)
        {
            yield return null;
        }
        yield return StartCoroutine(NegativeBlinker.instance.BlinkTimes(3));
    }

    public void GoToMenu()
    {
        GameManager.isWin = false;
        GameManager.isLose = false;
        SceneManager.LoadScene("Menu");
    }


}
