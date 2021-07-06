using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRotate : MonoBehaviour
{
    Rigidbody rb;


  
    public Vector3 eulerAngleVelocity ;
    public float direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

 

    private void FixedUpdate()
    {
        Rotate();

    }

    void Rotate()
    {

        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "stop")
        {
            eulerAngleVelocity = new Vector3(0, 0, 0);
        }

      


    }

    private void OnTriggerExit  (Collider other)
    {

        if (other.gameObject.tag == "stop")
        {
            eulerAngleVelocity = new Vector3(0, direction, 0);
        }




    }

}
