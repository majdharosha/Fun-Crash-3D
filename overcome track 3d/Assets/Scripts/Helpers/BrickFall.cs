using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFall : MonoBehaviour
{
    Vector3 initialpos;
    Quaternion initialrot;

    private void Start()
    {
         initialpos = transform.parent.transform.position;
        initialrot = transform.parent.transform.rotation;
    }

    private void OnTriggerEnter (Collider other )
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("FallDown", 0.3f);

        }

    }

    void FallDown  ()
    {
      

        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
       // Destroy(transform.parent.gameObject, 2f);

    }



    private void Update()
    {
        if (GameManager.instance.gameover)
        {
            Invoke("resetbrick", 2f);
        }
    }


    public  void resetbrick()
    {
        GetComponentInParent<Rigidbody>().useGravity = false;
        GetComponentInParent<Rigidbody>().isKinematic = true;
        transform.parent.transform.position = initialpos;
        transform.parent.transform.rotation = initialrot;
    }
}
