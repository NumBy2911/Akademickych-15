using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class CameraSens : MonoBehaviour
{
    public Slider sensitivitySlider;
    public CinemachineFreeLook cinemachineFreeLookCamera; // Assign in inspector

    void Start()
    {
        float savedSensitivity = PlayerPrefs.GetFloat("cameraSensitivity", 100f); // Default sensitivity
        sensitivitySlider.value = savedSensitivity;
        sensitivitySlider.onValueChanged.AddListener(delegate { AdjustSensitivity(); });

        // Apply saved sensitivity to CinemachineFreeLook component
        ApplySensitivity(savedSensitivity);
    }

    public void AdjustSensitivity()
    {
        float sensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat("cameraSensitivity", sensitivity);

        ApplySensitivity(sensitivity);
    }

    private void ApplySensitivity(float sensitivity)
    {
        if (cinemachineFreeLookCamera != null)
        {
            // Directly set the max speed for both axes
            cinemachineFreeLookCamera.m_XAxis.m_MaxSpeed = sensitivity; // Horizontal sensitivity
            
                                                                           // Assuming the Y Axis controls zoom or vertical tilt, you may adjust it as needed
        }
    }

}
