using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Pripoj sem tvoj UI Panel
    public StartCountdown countdownManager; // Pripoj sem objekt, ktor� m� skript pre odpo�et

    void Start()
    {
        // Zobraz� tutori�l pri ka�dom spusten� hry pre ��ely testovania
        ShowTutorial();
    }

    void Update()
    {
        // Skontroluje, �i je stla�en� medzern�k a zavrie tutori�lov� okno
        if (tutorialPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            HideTutorial();
        }
    }

    void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
        // Pozastavenie hry bude rie�en� mimo Time.timeScale
        Time.timeScale = 0f; // Pozastav� hru
    }

    void HideTutorial()
    {
        tutorialPanel.SetActive(false);
        countdownManager.BeginCountdown(); // Spust� odpo�et
    }
}

