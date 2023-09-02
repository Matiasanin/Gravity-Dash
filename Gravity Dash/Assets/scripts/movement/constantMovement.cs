using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class constantMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    private float timeSinceStart = 0.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        timeSinceStart += Time.deltaTime;

        // Automatically move the player to the right
        float baseSpeedPerSecond = speed + Mathf.Min((timeSinceStart - 60.0f) / 60.0f, 3.0f);
        transform.Translate(Vector3.right * baseSpeedPerSecond * Time.deltaTime);
        Debug.LogError("Current Speed" + baseSpeedPerSecond);
    }
}