using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    Vector3 offset;
    public float lerpRate;
    public Quaternion newrot;
    public Transform camPos1, camPos2 , camPos3,CamPos4;
    public bool frontview , sideview, view3, Winview ;
    Transform camParent; 

    void Start()
    {
        camParent = transform.parent.GetComponent<Transform>(); 
        offset = target.transform.position - transform.position;

        frontview = true;
        sideview = false;
        view3 = false;
        Winview = false;
    }

    void Update()
    {
        Vector3 pos = camParent.position ;

        if (target != null)
        {
            Vector3 targetpos = target.transform.position - offset;
            pos = Vector3.Lerp(pos, targetpos, lerpRate * Time.deltaTime);
        }

        camParent.position = pos;




        if (sideview)
        {
            frontview = false;
            view3 = false;
            transform.position = Vector3.Lerp(transform.position, camPos2.position, 2.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos2.rotation, 2.5f * Time.deltaTime);
        }
        if (frontview)
        {
            sideview = false;
            view3 = false;
            transform.position = Vector3.Lerp(transform.position, camPos1.position, 2.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos1.rotation, 2.5f * Time.deltaTime);
        }

        if (view3)
        {
            sideview = false;
            frontview = false;
            transform.position = Vector3.Lerp(transform.position, CamPos4.position, 2.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, CamPos4.rotation, 2.5f * Time.deltaTime);
        }

        if (Winview)
        {
            sideview = false;
            frontview = false;
            view3 = false;
            transform.position = Vector3.Lerp(transform.position, camPos3.position, 2f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos3.rotation, 2f * Time.deltaTime);
        }


    }

    


   



}
