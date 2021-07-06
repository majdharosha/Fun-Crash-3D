using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{

    public float speed;
    bool dirRight = true;
    Rigidbody rb;
    public float range;
    

    void Start()
    {
       
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {

        
        
     
        if (dirRight)
        {
            rb.MovePosition(transform.position + transform.right *speed* Time.fixedDeltaTime);
        }
        else

        rb.MovePosition(transform.position + -transform.right *speed* Time.fixedDeltaTime);


        if (transform.localPosition.x >= range)
        {
            dirRight = false;
        }

        if (transform.localPosition.x <= -range)
        {
            dirRight = true;
        }

    }
}
