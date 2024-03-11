using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int targetsShot = 0;
    private float elapsedTime = 0;
    private float totalTime = 30;

    [SerializeField] private TextMeshProUGUI targetsText;
    [SerializeField] private TextMeshProUGUI timeText;

    public void ShotATarget()
    {
        targetsShot++;
    }

    private void UpdateUI()
    {
        targetsText.text = "Targets: " + targetsShot.ToString();
        timeText.text = elapsedTime.ToString();
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
        targetsShot = 0;
        elapsedTime = 0;
    }
}
