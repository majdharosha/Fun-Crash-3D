using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoint : MonoBehaviour
{



    RagDoll ragdolscript;
    Rigidbody rb; 



    private void Awake()
    {
       

        ragdolscript = GetComponentInParent<RagDoll>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      

    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {

                                   

            if (col.collider.gameObject.layer == LayerMask.NameToLayer("ragdollCollision"))
            {
                Player.instance.Enemy();
            }

            foreach (Rigidbody ragdoll in ragdolscript.ragdollsRBs)
            {
                ragdoll.mass = 5;
               
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            foreach (Rigidbody ragdoll in ragdolscript.ragdollsRBs)
            {
                ragdoll.mass = 0;

            }

            


        }
         

        if (other.gameObject.tag == "checkpoint")
        {
            if (Player.instance.playerCollider.enabled == false)
            {
                Player.instance.playerCollider.enabled = true;
            }
        }


        if (other.gameObject.tag == "Finish")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }

        if (other.gameObject.name == "freezebones")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "freezebones")
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePosition;

        }
    }

}
