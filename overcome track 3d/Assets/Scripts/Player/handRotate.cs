using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handRotate  : MonoBehaviour
{

    Rigidbody rb;
    public float forceamount;
    bool impact = false , impact2 = false;
    bool dirRight = true;
    public Vector3 eulerAngleVelocity;

  
    void Start()
    {
        

        rb = GetComponent<Rigidbody>(); 
    }


  
    void FixedUpdate()
    {



        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);





    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "right")
        {
            impact = true; 
            AddPushForceRight();
            UNFreeze();
        }
        
        if (col.gameObject.tag == "left")
        {
            impact2 = true;
            AddPushForceleft();
            UNFreeze();
        }

      

    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "slow")
        {
            eulerAngleVelocity = new Vector3 (0,0, 100);
        }

        if (other.gameObject.name == "fast")
        {
            eulerAngleVelocity = new Vector3(0, 0, 300);
        }


    }



    void UNFreeze()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationY & ~RigidbodyConstraints.FreezeRotationX
           & ~RigidbodyConstraints.FreezeRotationZ;
    }

    void AddPushForceRight  ()
    {
      
        rb.AddForce(forceamount , 2, 0, ForceMode.Impulse );

    }

    void AddPushForceleft ()
    {
        rb.AddForce(- forceamount , 2, 0, ForceMode.Impulse);


    }

}
