using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerIsAlive = true;
    public GameObject cube;
    public Logic logic;
    public GameObject cameraGO;
    public float deltaDistance;
    public AudioSource audiosource;
    public float flapforce= 50.0f;
    private bool canJump = true;
    private bool jumpUpwards = true; // Flag to toggle jump direction

    void Start()
    {
        Physics.gravity = new Vector3(0, flapforce, 0);
        audiosource = cube.GetComponent<AudioSource>();

    }

    void Update()
    {
        // Check for jumping input and ability to jump
        if (Input.GetKeyDown(KeyCode.Space) /*&& canJump*/)
        {
            UnityEngine.Debug.Log("space bar");
            Jump();
        }

        // Check if the player is out of bounds
        if (IsOutOfBounds())
        {
            HandleOutOfBounds();
        }
    }

   /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true; // Player can jump when touching the floor
            audiosource.Play();
        }
    }
*/
   /* void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = false; // Player can't jump until they press space bar again
        }
    }
   */
    void Jump()
    {
        UnityEngine.Debug.Log("jump");
        if (IsGrounded())
        {
            print("Hola");
            UnityEngine.Debug.Log("IsGrounded");
            Physics.gravity = new Vector3(0, flapforce, 0);
            flapforce = (-1) * flapforce;
            
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 0.00001f; // Adjust this value based on your needs

        // Cast a ray from the player's position downward to check for ground
        if (Physics.Raycast(cube.transform.position, Vector3.down, out hit))
        {
            // Check if the raycast hit something tagged as "Floor"
            /* if (hit.collider.CompareTag("Floor"))
             {
                 return true;
             }
            */
            return true;
        }
        else if (Physics.Raycast(cube.transform.position, Vector3.up, out hit, raycastDistance))
        {
            // Check if the raycast hit something tagged as "Floor"
            if (hit.collider.CompareTag("Floor"))
            {
                return true;
            }
            return true;
        }
        return false;
    }

    bool IsOutOfBounds()
    {
        Transform playerTransform = cube.GetComponent<Transform>();

        return playerTransform.position.y < -10 || playerTransform.position.y > 16 || playerTransform.position.x < -36;
    }

    void HandleOutOfBounds()
    {
        if (playerIsAlive)
        {
            playerIsAlive = false;
            logic.gameOver();
        }
        else if (cube.GetComponent<Transform>().position.x > 920)
        {
            playerIsAlive = false;
            logic.victory();
        }
        else if (cameraGO.transform.position.x - cube.GetComponent<Transform>().position.x > deltaDistance)
        {
            playerIsAlive = false;
            logic.gameOver();
        }
    }
}
