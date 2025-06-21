using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public float wheelDiameter = 0.5f; // Assume the wheel has a diameter of 0.5 meters
    private float circumference;
    public Transform carBody; // Reference to the car body to calculate movement speed

    private Vector3 lastPosition;
    private float distanceMoved;

    void Start()
    {
        circumference = Mathf.PI * wheelDiameter; // Calculate the circumference of the wheel
        lastPosition = carBody.position;
    }

    void Update()
    {
        // Calculate how far the car has moved since the last frame
        distanceMoved = Vector3.Distance(carBody.position, lastPosition);
        lastPosition = carBody.position;

        // Calculate the rotation amount
        float rotationAmount = (distanceMoved / circumference) * 360; // How many degrees to rotate the wheel based on the distance moved

        // Rotate the wheel
        transform.Rotate(0f, 0f, rotationAmount * Time.deltaTime, Space.Self);
    }
}