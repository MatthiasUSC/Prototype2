using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 30)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 30 && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.red;
        }
        else
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
