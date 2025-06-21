using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 0f;
    [SerializeField] Text timerText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
