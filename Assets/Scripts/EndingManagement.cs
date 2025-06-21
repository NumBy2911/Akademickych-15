using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManagement : MonoBehaviour
{
    [SerializeField] Text timerText;
    private ManagementParameters managementParametersInstance;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        managementParametersInstance = FindObjectOfType<ManagementParameters>();

        if (managementParametersInstance != null)
        {
            int minutes = Mathf.FloorToInt(managementParametersInstance.getFinishedTime() / 60);
            int seconds = Mathf.FloorToInt(managementParametersInstance.getFinishedTime() % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.Log("PersistentObject not found in this scene.");
        }
        
    }
    public void MenuScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
