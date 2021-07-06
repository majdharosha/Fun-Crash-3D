using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public float speedA , speedB ;
    bool dirRight = true;
    Rigidbody rb;
    public float range;
    public GameObject stopTrigger; 

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      
        
    }

    void FixedUpdate()
    {




        if (dirRight)
        {
            rb.MovePosition(transform.position + transform.right * speedA * Time.fixedDeltaTime);
        }
        else

            rb.MovePosition(transform.position + -transform.right * speedB * Time.fixedDeltaTime);


        if (transform.localPosition.x >= range)
        {
          
            dirRight = false;
        }

        if (transform.localPosition.x <= -range)
        {
            dirRight = true;
           
        }

        



    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "punchstop")
        {
            speedA = 0;
            speedB = 0;
        }

    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.name == "punchstop")
        {
            speedA = 7;
            speedB = 20;
        }

    }


}
