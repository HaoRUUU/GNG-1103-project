using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer2SceneChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime; // Set the start time in Inspector
    [SerializeField] private int nextSceneIndex; // Scene index to change to

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0) remainingTime = 0; // Prevent negative time

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            // Null check before updating the text
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                // Change text color to red when time runs out
                if (remainingTime <= 6)
                {
                    timerText.color = Color.red;
                }
            }
        }

        // Change scene when time runs out
        if (remainingTime <= 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(5); // Use serialized scene index
    }
}