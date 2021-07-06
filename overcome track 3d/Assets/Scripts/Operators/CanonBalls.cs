using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBalls : MonoBehaviour
{

    public GameObject ball;
    Rigidbody rb;
    public float launchforce , upforce;

    [SerializeField]
    
    private void Awake()
    {
        rb = ball.GetComponent<Rigidbody>();
    }



    private void Start()
    {
        InvokeRepeating("throughBalls", 3f, 3f);
    }


    private void Update()
    {
       


    }

    private void FixedUpdate()
    {
        Addforce();

    }

    void throughBalls()
    {


        


        GameObject newBall = Instantiate(ball , transform.position , transform.rotation );
       
        Rigidbody newballrb = newBall.GetComponent<Rigidbody>();
        newballrb.AddForce(transform.forward * launchforce, ForceMode.Impulse);
        Destroy(newBall, 3.5f);

    }

    void Addforce()
    {
        
    }


}
