using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text levelText;

    public GameObject winPanel, losePanel;

    int playTime = 60;
    public Text timerText;
    int seconds, minutes;
    bool hasWon;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        UpdateTimerText();
        StartCoroutine("Timer");
    }

    void UpdateTimerText()
    {
        seconds = playTime % 60;
        minutes = playTime / 60 % 60;

        timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

    }

    IEnumerator Timer()
    {
        while(playTime > 0)
        {
            yield return new WaitForSeconds(1);
            playTime--;
           
            UpdateTimerText();
        }

        Debug.Log("Time is over");
       // Puzzle.instance.DeactivateAllTiles();
        losePanel.SetActive(true);
    }
    //stop timer if puzzle solved

    public void HasWon()
    {
        hasWon = true;
        //StopAllCoroutines();
        StopCoroutine("Timer");
        winPanel.SetActive(true);

    }
    
}
