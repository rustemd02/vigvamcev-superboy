using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    private float timer = 5;
    public TextMeshProUGUI timerText;
    public Boss boss;


    private void Update()
    {
        if (isTriggered)
        {
            Timer();
        }
    }

    void Timer()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
        } else
        {
            boss.Shoot();
            timer += 5; 
        }
        DisplayTime(timer);
    }
    
    void DisplayTime(float currentTimerValue)
    {
        float seconds = Mathf.FloorToInt(currentTimerValue % 60);
        timerText.text = $"{seconds:0}";
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Trigger1") && !isTriggered)
        {
            Time.timeScale = 0.2f;
        }
        else if (gameObject.CompareTag("Trigger2"))
        {
            isTriggered = true;
            Time.timeScale = 1f;
        }
    }
}
