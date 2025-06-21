using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Pripoj sem tvoj UI Panel
    public StartCountdown countdownManager; // Pripoj sem objekt, ktorý má skript pre odpoèet

    void Start()
    {
        // Zobrazí tutoriál pri každom spustení hry pre úèely testovania
        ShowTutorial();
    }

    void Update()
    {
        // Skontroluje, èi je stlaèený medzerník a zavrie tutoriálové okno
        if (tutorialPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            HideTutorial();
        }
    }

    void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
        // Pozastavenie hry bude riešené mimo Time.timeScale
        Time.timeScale = 0f; // Pozastaví hru
    }

    void HideTutorial()
    {
        tutorialPanel.SetActive(false);
        countdownManager.BeginCountdown(); // Spustí odpoèet
    }
}

