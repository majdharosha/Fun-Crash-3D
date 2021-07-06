using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SideLevel : MonoBehaviour
{

    public static SideLevel instance;
    public bool sideLevel ;

    void Awake()
    {
        try
        {
            instance = this;
        }

        catch (NullReferenceException e)
        {

        }

      

    }


    void Start()
    {
       
        
    }


    void Update()
    {
        
    }
}
