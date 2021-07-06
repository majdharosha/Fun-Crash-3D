﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollcollider : MonoBehaviour
{
    // Start is called before the first frame update



    private void Update()
    {
        if (GameManager.instance.gameover)
        {
            GetComponent<Collider>().enabled = true;
        }

       
    }
  
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            GetComponent<Collider>().enabled = false;
        }
    }


}
