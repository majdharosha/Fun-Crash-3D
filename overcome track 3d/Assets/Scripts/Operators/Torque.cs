using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
 

    Rigidbody rb;
    public Vector3 TorqueForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
      
    }

    private void FixedUpdate()
    {
        rb.AddTorque(TorqueForce, ForceMode.Acceleration);

    }


 

  
}
