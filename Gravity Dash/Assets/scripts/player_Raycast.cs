using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerIsAlive = true;
    public GameObject cube;
    public Logic logic;
    public GameObject cameraGO;
    public float deltaDistance;
    public AudioSource audiosource;
    // Adjust this force as needed
    public float jumpForce = 50.0f;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = cube.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for jumping input and collision with the floor
        if (Input.GetKeyDown(KeyCode.Space) && hit)
        {
            Jump();
        }

        // Check if the player is out of bounds
        if (IsOutOfBounds())
        {
            HandleOutOfBounds();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hit = true;
            audiosource.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        hit = false;
    }

    private void Jump()
    {
       
        Vector3 jumpDirection = Vector3.up * jumpForce;

        // Cast a ray upwards to check for obstacles before applying the jump
        RaycastHit obstacleHit;
        float obstacleCheckDistance = 1.0f; // Adjust this value based on your needs

        if (!Physics.Raycast(transform.position, Vector3.up, out obstacleHit, obstacleCheckDistance))
        {
            // No obstacle detected, apply the jump force
            cube.GetComponent<Rigidbody>().AddForce(jumpDirection, ForceMode.Impulse);
        }
    }

    private bool IsOutOfBounds()
    {
        Transform playerTransform = cube.GetComponent<Transform>();

        return playerTransform.position.y < -10 || playerTransform.position.y > 16 || playerTransform.position.x < -36;
    }

    private void HandleOutOfBounds()
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