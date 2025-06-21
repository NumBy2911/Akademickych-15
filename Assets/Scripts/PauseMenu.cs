using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Start Screen"); 
    }
}
