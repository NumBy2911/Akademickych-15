using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartCountdown : MonoBehaviour
{
    public Text countdownText; // Assign in inspector

    private bool startCountdown = false;

    void Update()
    {
        if (startCountdown)
        {
            StartCoroutine(CountdownToStart());
            startCountdown = false; // Prevent starting countdown multiple times
        }
    }

    public void BeginCountdown()
    {
        startCountdown = true;
    }

    IEnumerator CountdownToStart()
    {
        // Pause the game at start
        Time.timeScale = 0f;

        float pauseEndTime = Time.realtimeSinceStartup + 4; // 3 seconds + "Go!"
        int count = 3;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            if (count > 0)
            {
                countdownText.text = count.ToString();
                yield return new WaitForSecondsRealtime(1f);
                count--;
            }
            else
            {
                countdownText.text = "Go!";
                yield return new WaitForSecondsRealtime(1f);
                countdownText.gameObject.SetActive(false); // Hide the countdown text
                break;
            }
        }

        // Resume the game after countdown
        Time.timeScale = 1f;
    }
}
