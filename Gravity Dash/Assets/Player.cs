using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float flapforce= 50;
    public bool playerIsAlive = true;
    public GameObject cube;
    public Transform transform;

    public Logic logic;


    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hit )
        {
            Physics.gravity = new Vector3(0, flapforce, 0);
            flapforce = (-1) * flapforce;
  
        }
        

        transform = cube.GetComponent<Transform>();

        if((transform.position.y < -6) || (transform.position.y > 12) || (transform.position.x < -36))
        {
            /*
            if (playerIsAlive)
            {
                playerIsAlive = false;
                logic.gameOver();
            }
            */

        }
        else if(transform.position.x > 36)
        { 
         /*
          playerIsAlive = false;
          logic.victory();
          */
        
        }

        
        

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            hit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        hit = false;
    }
}
