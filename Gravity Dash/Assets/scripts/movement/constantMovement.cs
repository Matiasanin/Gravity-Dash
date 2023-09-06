using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class constantMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    public float acceleration;
    public Rigidbody rigid; 

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
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        speed += acceleration * Time.deltaTime;
        rigid.velocity = new Vector3(speed, rigid.velocity.y, rigid.velocity.z);
    }
}