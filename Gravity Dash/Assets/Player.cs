using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float flapforce= 50;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Physics.gravity = new Vector3(0, flapforce, 0);
            flapforce = (-1) * flapforce;
  
                }

    }
}
