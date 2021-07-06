using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

   

    void Start()
    {
        

    }

    void Update()
    {
        
    }

   

    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
           LevelSystem.currentcheckpoint = gameObject;
        }
          
    }

}
