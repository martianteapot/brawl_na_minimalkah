using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public static bool timerIsRunning = false;
    public Text timeText;
    public Animator animator;
    public Animator animator2;
    public GameObject spawnEnemies;
    public GameObject loot;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                animator.SetBool("endLevel", true);
                animator2.SetBool("endLevel", true);
                Destroy(spawnEnemies);
                Destroy(loot);
                    
        
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/