using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransparentAlpha : MonoBehaviour
{

    public static TransparentAlpha instance; 
    public MeshRenderer[] fanMat;
    public bool alpha;
    private MeshRenderer rendermode;

  
    private void Awake()
    {

        if (this == null)
        {
            Destroy(gameObject);
        }


        if (instance == null)
        instance = this;


       if (fanMat != null)
        fanMat = GetComponentsInChildren<MeshRenderer>();

      
        try
        {
        rendermode = transform.GetChild(0).GetComponent<MeshRenderer>();

        }
        catch (NullReferenceException e)
        {

        }

      
        


    }

    private void Update()
    {
     

        if (alpha)
        {
            foreach (MeshRenderer fan in fanMat)
            {
                fan.material.color = new Color(1, 1, 1, 0.1f);
     
            }
     
            rendermode.enabled = false;
           
     
        }
        
        

        if (!alpha)
        {
            foreach (MeshRenderer fan in fanMat)
            {
                fan.material.color = new Color(1, 1, 1, 1f);
            }
            rendermode.enabled = true;
        }


        if (Player.instance.anim.enabled == false)
        {
            Invoke("Alphafalse", 1.9f);
        }
      
    }

  


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            alpha = true;
        }
    }


    void Alphafalse ()
    {
        alpha = false;
    }

}
