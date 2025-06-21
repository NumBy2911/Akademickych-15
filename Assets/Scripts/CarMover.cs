using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public Transform[] targets;
    private int currentTargetIndex = 0;
    public float speed = 5.0f;

    void Update()
    {
        if (targets.Length == 0) return;

        Transform target = targets[currentTargetIndex];
        Vector3 targetPositionFlat = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 direction = (targetPositionFlat - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Calculate the correct forward vector
        Vector3 correctForward = Quaternion.Euler(0, -90, 0) * direction; // Adjust based on your model's forward direction
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(correctForward, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speed * Time.deltaTime * 100.0f);
        }

        if (Vector3.Distance(transform.position, targetPositionFlat) < 0.5f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }
    }
}
