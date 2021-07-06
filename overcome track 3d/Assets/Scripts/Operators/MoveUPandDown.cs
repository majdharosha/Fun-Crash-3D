using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUPandDown : MonoBehaviour
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
            rb.MovePosition(transform.position + transform.up* speed * Time.fixedDeltaTime);
        }
        else

            rb.MovePosition(transform.position + -transform.up * speed * Time.fixedDeltaTime);


        if (transform.localPosition.y >= range)
        {
            dirRight = false;
        }

        if (transform.localPosition.y <= -range)
        {
            dirRight = true;
        }

    }


}
