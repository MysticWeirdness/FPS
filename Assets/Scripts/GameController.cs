using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int targetsShot = 0;
    private float elapsedTime = 0;
    private float totalTime = 30;
    private const string HIGHSCOREPREFIX = "Highscore\n       ";

    [SerializeField] private TextMeshProUGUI targetsText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private GameObject Menu;
    [SerializeField]

    public void ShotATarget()
    {
        targetsShot++;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }
    private void UpdateUI()
    {
        targetsText.text = "Targets: " + targetsShot.ToString();
        timeText.text = "Time Elapsed: " + ((int)elapsedTime).ToString();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= totalTime)
        {
            Restart();
        }
        UpdateUI();
    }

    private void Restart()
    {
        Time.timeScale = 0f;
        targetsShot = 0;
        elapsedTime = 0;
        Menu.SetActive(true);
        if(targetsShot > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", targetsShot);
            highscoreText.text = HIGHSCOREPREFIX + targetsShot.ToString();
        }
        else
        {
            highscoreText.text = HIGHSCOREPREFIX + PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
