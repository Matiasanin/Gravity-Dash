using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class _Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float flapforce= 50;
    public bool playerIsAlive = true;
    public GameObject cube;
    public new Transform transform;
    public float speed;
    public Logic logic;
    public GameObject cameraGO;
    public float deltaDistance;
    public AudioSource audiosource;
    public float raydistance= 4;
    


    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (hit || IsGrounded() ))
        {
            Physics.gravity = new Vector3(0, flapforce, 0);
            flapforce = (-1) * flapforce;
        }
        

        transform = cube.GetComponent<Transform>();
        audiosource = cube.GetComponent<AudioSource>();

        if((transform.position.y < -10) || (transform.position.y > 16) || (transform.position.x < -36))
        {
            if (playerIsAlive)
            {
                playerIsAlive = false;
                logic.gameOver();
            }
        }
        else if(transform.position.x > 920)
        { 
          playerIsAlive = false;
          logic.victory();
        }
        if (cameraGO.transform.position.x-transform.position.x > deltaDistance)
        {
            if (playerIsAlive)
            {
                playerIsAlive = false;
                logic.gameOver();
            }
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        

        // Cast a ray from the player's position downward to check for ground
        if (Physics.Raycast(cube.transform.position, Vector3.down, out hit, raydistance))
        {
            print("hola");
            
            return true;
        }
        else if (Physics.Raycast(cube.transform.position, Vector3.up, out hit, raydistance) )
        {
            print("hola");
            return true;
        }
        return false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            hit = true;
            audiosource.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        hit = false;
    }

    public void GameOver()
    {
        if (playerIsAlive)
        {
            playerIsAlive = false;
            logic.gameOver();
        }
    }
}
