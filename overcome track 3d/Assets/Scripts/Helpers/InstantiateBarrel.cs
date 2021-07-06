using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBarrel : MonoBehaviour
{

    public GameObject barrel;

  
   

    private void Awake()
    {
      

    }
    void Start()
    {
        InvokeRepeating("launchBarrel", 1.5f, 1.5f);
    }

  


    void launchBarrel()
    {
        GameObject newBarrel = Instantiate(barrel, transform.position, transform.rotation);

       
        Destroy(newBarrel, 20f);
    }
}
