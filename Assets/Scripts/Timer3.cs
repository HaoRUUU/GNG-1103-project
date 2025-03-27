using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer3SceneChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime = 30f; // Default 30s if not set in Inspector
    [SerializeField] private int nextSceneIndex = 1; // Scene index to load

    void Start()
    {
        Time.timeScale = 1; // Ensure time is running
        Debug.Log("Timer Started: " + remainingTime);
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            remainingTime = Mathf.Max(remainingTime, 0); // Prevent negative time

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            if (timerText != null)
            {
                timerText.text = $"{minutes:00}:{seconds:00}";

                if (remainingTime <= 6)
                {
                    timerText.color = Color.red; // Change color when time is low
                }
            }

            Debug.Log("Remaining Time: " + remainingTime); // Check if timer updates
        }

        if (remainingTime <= 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        Debug.Log("Changing Scene to: " + 6);
        SceneManager.LoadScene(6); // Load next scene
    }
}