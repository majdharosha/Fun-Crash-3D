using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    
   
    Rigidbody rb;


    public Vector3 eulerAngleVelocity; 


   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
      

    }

    private void Start()
    {
        
    }


    void Update()
    {

       
        

      //  if (rotateaxis == RotateAxis.z)
      //  {
      //      transform.Rotate(Vector3.forward * Rotatespeed * Time.deltaTime);
      //  }
      //
      //  if (rotateaxis == RotateAxis.y)
      //  {
      //      transform.Rotate(Vector3.up * Rotatespeed * Time.deltaTime);
      //  }
      //
      //  if (rotateaxis == RotateAxis.x)
      //  {
      //      transform.Rotate(Vector3.right * Rotatespeed * Time.deltaTime);
      //  }
      //
      //  if (rotateaxis == RotateAxis.nz)
      //  {
      //      transform.Rotate(- Vector3.forward * Rotatespeed * Time.deltaTime);
      //  }
      //
      //  if (rotateaxis == RotateAxis.ny)
      //  {
      //      transform.Rotate(- Vector3.up * Rotatespeed * Time.deltaTime);
      //  }
      //
      //  if (rotateaxis == RotateAxis.nx)
      //  {
      //      transform.Rotate(- Vector3.right * Rotatespeed * Time.deltaTime);
      //  }
      //

    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }




}
