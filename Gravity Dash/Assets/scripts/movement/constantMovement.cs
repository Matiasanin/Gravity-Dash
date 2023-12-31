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
        // Automatically move the player to the right
        //transform.Translate(Vector3.right * speed * Time.deltaTime);

        speed += acceleration * Time.deltaTime;
        rigid.velocity = new Vector3(speed, rigid.velocity.y, rigid.velocity.z);
    }
}