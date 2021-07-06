using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RagDoll : MonoBehaviour
{

    public Rigidbody[] ragdollsRBs  ;
    Collider[] ragdolls;
    Transform bones;
    Collider[] coins;
    GameObject[] coinarrray;
    private void Awake()
    {

        ragdollsRBs = GetComponentsInChildren<Rigidbody>();
        bones = transform.GetChild(0).transform;
        ragdolls = GetComponentsInChildren<Collider>();

       
    }

    void Start()
    {


  
    }

    void Update()
    {
        if (Player.instance.dead)
        { 
            foreach (Rigidbody ragdoll in ragdollsRBs)
            {
               
                UNFreeze();
            }
       
       
            Invoke("Freeze", 1.8f);     
            Invoke("ResetToPosition", 2.1f);
            
        }
        Player.instance.dead = false;

                    
    }

  

    private void ResetToPosition()
    {
        bones.transform.localPosition = new Vector3(-0.002242689f, 0.6632444f, 0.002208189f);
        bones.transform.localRotation = Quaternion.Euler(-3.738f, 5.238f, 3f);

    }



    public void UNFreeze()
    {


        foreach (Rigidbody ragdoll in ragdollsRBs)
        {
            ragdoll.constraints &= ~RigidbodyConstraints.FreezeRotation ;

        }
     
    }

    public void Freeze()
    {

         foreach (Rigidbody ragdoll in ragdollsRBs)
         {
             ragdoll.constraints = RigidbodyConstraints.FreezeRotation;
                   
         }
       
    }


    private void OnTriggerEnter(Collider other)
    {
    

      //  if (other.gameObject.tag == "Finish")
      //  {
      //      Player.instance.Freeze();
      //  }

      

     

    }



    private void OnTriggerExit(Collider other)
    {
      //  if (other.gameObject.tag == "SideView")
      //  {
      //      Camera.main.GetComponent<CameraFollow>().sideview = false;
      //      Camera.main.GetComponent<CameraFollow>().frontview = true;
      //      Camera.main.GetComponent<CameraFollow>().view3 = false;
      //
      //  }

      //  if (other.gameObject.tag == "view3")
      //  {
      //      Camera.main.GetComponent<CameraFollow>().sideview = false;
      //      Camera.main.GetComponent<CameraFollow>().frontview = false;
      //      Camera.main.GetComponent<CameraFollow>().view3 = true;
      //
      //
      //  }



      //  if (other.gameObject.tag == "LargeFanCrouch" || other.gameObject.tag == "hotdogCrouch" ||
      //     other.gameObject.tag == "windowsCrouch")
      //  {
      //      
      //      Player.instance.anim.SetTrigger("idle");
      //
      //  }

    }

 


}
