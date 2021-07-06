using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{

    public static Player instance; 
    Rigidbody rb;
    public Collider playerCollider;
    public float speed, jumpforce, climbspeed, LRSpeed, slideforce;
   
    public bool jump = false, canMove = true , climb = false, dead , timeactive = true,  jumpstate;
    public Vector3 cornerRotate ;
    public bool leftrotate, rightrotate;
    private Vector3 lastMousePos;
    public float sensitivity = .16f, clampDelta = 42f;
    public Vector3 velocityjump = new Vector3(0,0,11);


    public GameObject target, bodycollider;
    public Animator anim;

    private Collider[] LargeFancolliders;
    private Collider[] windows;
    private Collider hotdog;
    private Arrays arrays; 
    [HideInInspector]
    public bool IsPlayerMoving , frontfall, thrownleft , thrownright , thrownback, fallflat, fallbottom;
    private bool slide, IsGrounded, falling, extragravity;
    public float turnDegree ;
    




    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Finish
    }

    public PlayerState playerstate = PlayerState.Prepare;

    void Awake()
    {

       

        instance = this;

        arrays = FindObjectOfType<Arrays>();
       
     
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();

        if (hotdog != null)
        hotdog = GameObject.Find("hotdog").GetComponent<BoxCollider>();
       
       


    }

    private void Start()
    {







        try
        {
            LargeFancolliders = GameObject.Find("large_fan_2").GetComponentsInChildren<BoxCollider>();
        }
        catch (NullReferenceException e)
        {

        }




        try
        {
            hotdog = GameObject.Find("hotdog").GetComponent<BoxCollider>();
        }
        catch (NullReferenceException e)
        {

        }




        try
        {
            windows = arrays.windows;
        }
        catch (NullReferenceException e)
        {

        }
       



        timeactive = true;


    }


    void Update()
    {


        if (windows != null)
            windows = arrays.windows;





        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Jump Over"))
        {
            jumpstate = true;
           
        }
        else
        {
            jumpstate = false;
          
        }


        



        if (slide)
        {

             canMove = false;

            transform.position += new Vector3(0, 0, slideforce * Time.smoothDeltaTime);
            transform.position += new Vector3(0, -4f * Time.smoothDeltaTime, 0);


        }
        



        if (!jumpstate)
        {
            MovePlayer();
        }
         
        
        if (jump)
        {
            jump = false;
        }



        AnimatePlayer();

  






        anim.SetBool("climb", climb);
        anim.SetBool("slide", slide);
        anim.SetBool("playermoving", IsPlayerMoving);
        

        ResetTriggers();


        try
        {
            if (SideLevel.instance.sideLevel)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.7f, 4.7f), transform.position.y, transform.position.z);
            }
        }

        catch (NullReferenceException e)
        {

        }


       




        if (!rightrotate && !leftrotate)
        {
              if (transform.eulerAngles.y < 100 && transform.eulerAngles.y > 82)
              {
            
                  transform.rotation = Quaternion.Euler(0, 90, 0);
              }
            
              else if (transform.eulerAngles.y < 190 && transform.eulerAngles.y > 170)
              {
            
                  transform.rotation = Quaternion.Euler(0, 180, 0);
              }



            if (transform.eulerAngles.y > 260.0f && transform.eulerAngles.y < 280.0f)
            {

                transform.eulerAngles = new Vector3(0, 270, 0);
            }

         


            if (transform.eulerAngles.y > -10.0f && transform.eulerAngles.y < 10.0f)
            {

                transform.rotation = Quaternion.Euler(0, 0, 0);
            }


        }


       
       
    }



    void MovePlayer()
    {
        if (playerstate == PlayerState.Playing && canMove && timeactive)
        {

            if (Input.GetMouseButton(0) && !climb && IsGrounded)
            {

                rb.useGravity = true;
            
                Move();

               
              
               

                if (leftrotate)
                {
                    // transform.Rotate(-cornerRotate * Time.deltaTime);
                    RotatePlayerLeft();
                }

                if (rightrotate)
                {
                    // transform.Rotate(cornerRotate * Time.deltaTime);
                    RotatePlayerRight();
                }

            }

                
               


            if (climb && Input.GetMouseButton(0))
            {
                rb.useGravity = false;
              
                Climb();
            }
        }

         

       

      

    }


    void RotatePlayerRight()
    {
   
         transform.Rotate(0, 1 * turnDegree  * Time.deltaTime, 0);
       
         


    }



    void RotatePlayerLeft ()
    {
         transform.Rotate(0, - 1 * turnDegree  * Time.deltaTime, 0);           
    }




    void AnimatePlayer ()
    {

        if ((playerstate == PlayerState.Playing && canMove ))
        {
            if (Input.GetMouseButton(0))
            {
                if (!IsPlayerMoving)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running")
                      // && !anim.GetCurrentAnimatorStateInfo(0).IsName("FrontFall")
                      // && !anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Back")
                      // && !anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Left")
                     //  && !anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Right")                                       
                       && !anim.GetCurrentAnimatorStateInfo(0).IsName("Climb")
                     //   && !anim.GetCurrentAnimatorStateInfo(0).IsName("Fall Flat")
                        && !anim.GetCurrentAnimatorStateInfo(0).IsName("Sliding")
                        // && !anim.GetCurrentAnimatorStateInfo(0).IsName("Fall Bottom")
                       // && !anim.GetCurrentAnimatorStateInfo(0).IsName("Jump Over")
                       // && !anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")
                       )
                    {
                        IsPlayerMoving = true;

                       
                        anim.SetTrigger("run");
                       
                         

                    }
                }
                anim.SetFloat("climbSpeed", 1.2f);

            }
            else
            {
                if (IsPlayerMoving)
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running")
                     //   || anim.GetCurrentAnimatorStateInfo(0).IsName("FrontFall")
                     //   || anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Back")
                     //  || anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Left")
                     //  || anim.GetCurrentAnimatorStateInfo(0).IsName("Thrown Right")                    
                       || anim.GetCurrentAnimatorStateInfo(0).IsName("Climb") 
                      // || anim.GetCurrentAnimatorStateInfo(0).IsName("Fall Flat")
                       || anim.GetCurrentAnimatorStateInfo(0).IsName("Sliding")
                       || anim.GetCurrentAnimatorStateInfo(0).IsName("Jump Over")
                       || anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")
                      // ||anim.GetCurrentAnimatorStateInfo(0).IsName("Fall Bottom")
                       )
                    {
                        IsPlayerMoving = false;
                        
                       
                        anim.SetTrigger("stop");
                       

                    }

                }
                anim.SetFloat("climbSpeed", 0f);

            }

        }
       



    }

  



    private void FixedUpdate()
    {
        if (playerstate == PlayerState.Playing && canMove)
        {


           
            try
            {
                if (SideLevel.instance.sideLevel)
                {
                  

                    LeftRightMove();
                }
            }

            catch (NullReferenceException e)
            {

            }


        }

        
        if (extragravity)
        {
            rb.AddForce(new Vector3(0, -150, 0), ForceMode.Force);
        }


    }


 

    public void Move ()
    {
       
         transform.Translate(0, 0, speed * Time.deltaTime);

        // rb.MovePosition(transform.position + transform.forward * speed);

        // rb.velocity = new Vector3(0, 0, speed * Time.deltaTime );
        // rb.AddForce(0, 0, speed);

       
    }

    void LeftRightMove()
    {

        // Vector3 movex = new Vector3(Input.GetAxis("Mouse X"), 0, 0);

        // transform.Translate(movex.x * LRSpeed * Time.smoothDeltaTime, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;

        }

        if (canMove)
        {
            if (Input.GetMouseButton(0))
            {

                Vector3 vector = lastMousePos - Input.mousePosition;
                lastMousePos = Input.mousePosition;
                vector = new Vector3(vector.x * LRSpeed * Time.smoothDeltaTime, 0, 0);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);

                rb.AddForce(-moveForce * sensitivity - rb.velocity / 2, ForceMode.VelocityChange);

                 //transform.Translate(-moveForce * Time.smoothDeltaTime * sensitivity - rb.velocity / 4);
               

            }
        }
        rb.velocity.Normalize();

    }

    public void Climb()
    {
       rb.MovePosition(transform.position + transform.up * climbspeed * Time.deltaTime);
    }

    public void Jump ()
    {

       
          anim.SetTrigger("jump");
        
        
         rb.AddForce(new Vector3(0, jumpforce , 0), ForceMode.Impulse);
         rb.AddForce(velocityjump , ForceMode.VelocityChange);

       
         
       
    }

    public void UNFreeze()
    {
      //  rb.constraints &= ~RigidbodyConstraints.FreezeRotationY & ~RigidbodyConstraints.FreezeRotationX
      //     & ~RigidbodyConstraints.FreezeRotationZ ;


    }

    public void unfreezeposition()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePosition;
        
    }
    public  void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }

   

    void ResetTriggers()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump Over") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
             anim.ResetTrigger("jump");
             
        }

        

    }

    void EnableFinish()
    {
        LevelSystem.instance.Finish();
        GameUI.instance.finishUI.SetActive(true);
    }

    void Canmove()
    {
        canMove = true;
    }

    void EnableTrigger2()
    {
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }


    private void RestartState ()
    {
        
        rb.isKinematic = false;
        anim.enabled = true;
       

    }

    private void enableCollider ()
    {
        playerCollider.enabled = true;
       
    }


    void disableAnimator ()
    {
        anim.enabled = false;
    }



   
   
   

    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.tag == "SideView")
        {
           
           Camera.main.GetComponent<CameraFollow>().sideview = true;
            Camera.main.GetComponent<CameraFollow>().frontview = false ;
            Camera.main.GetComponent<CameraFollow>().view3 = false;

        }

        if (other.gameObject.tag == "view3")
        {

            Camera.main.GetComponent<CameraFollow>().sideview = false;
            Camera.main.GetComponent<CameraFollow>().frontview = false;
            Camera.main.GetComponent<CameraFollow>().view3 = true;

        }


        if (other.gameObject.tag == "ferris")
        {
            IsGrounded = true;
        }
        

        if (other.gameObject.tag == "Finish" && playerstate == PlayerState.Playing)
        {
            playerstate = PlayerState.Finish;
            Invoke("EnableFinish", 3f);
            canMove = false;
            GameUI.instance.inGameUI.SetActive(false);
            anim.Play("Samba Dancing");

            Camera.main.GetComponent<CameraFollow>().Winview = true;
            Camera.main.GetComponent<CameraFollow>().frontview = false;
            Camera.main.GetComponent<CameraFollow>().sideview = false;
            Camera.main.GetComponent<CameraFollow>().view3 = false;

            GameManager.instance.StartWinParticles();
            GameManager.instance.win = true;

            


        }


        if (other.gameObject.tag == "checkpoint")
        {



           

           





            if (anim.enabled == false)
            {
                    anim.enabled = true;
            }



                if (climb)
                {
                  // Invoke("unfreezeposition", 0.1f);
                   climb = false;
                }


                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump Over")  
                    || anim.GetCurrentAnimatorStateInfo(0).IsName("Climb")
                    || anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")
                   )
                {


                    if (IsPlayerMoving  )
                    {

                         anim.Play("Running");
                    }
                    else
                    {
                       anim.Play("Idle");
                    }
                  

                   


                }


                anim.ResetTrigger("crouch");

                leftrotate = false;
                rightrotate = false;



           


        }

        if (other.gameObject.tag == "LargeFanCrouch")
        {
            anim.SetTrigger("crouch");
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {
                
                foreach (Collider box in LargeFancolliders)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, true);
                }


            }
            else
            {
                foreach (Collider box in LargeFancolliders)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, false);
                }
            }

        }


        if (other.gameObject.tag == "hotdogCrouch")
        {
            anim.SetTrigger("crouch");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {

                Physics.IgnoreCollision(GetComponent<BoxCollider>(), hotdog, true);

            }
            else
            {


                Physics.IgnoreCollision(GetComponent<BoxCollider>(), hotdog, false);


            }

        }



        if (other.gameObject.tag == "windowsCrouch")
        {
            anim.SetTrigger("crouch");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {
                foreach (Collider box in windows)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, true);
                }


            }
            else
            {
                foreach (Collider box in windows)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, false);
                }
            }

        }


        if (other.gameObject.tag == "slide")
        {
            slide = true; 
        }


        if (other.gameObject.tag == "JumpPad")
        {
           
              jump = true;
            
            
            jumpstate = true;

            if (jump )
            {
                Jump();
            }
          

        }

      


        if (other.gameObject.tag == "deathtrigger")
        {


            if (!GameManager.instance.gameover)
            {
                GameManager.instance.gameover = true;
            }
               
            if (!dead)
            {
                dead = true;
            }
            
            if (Camera.main.GetComponent<CameraFollow>().target != null)
            {
                Camera.main.GetComponent<CameraFollow>().target = null;
            }
            
           
           
            if (canMove)
            {
                canMove = false;
            }
            
           
                   
           
            if (anim.enabled == true)
            {
                anim.enabled = false;
            }
           
            

        }


        if (other.gameObject.name == "setmiddle")
        {
            transform.position = GameObject.Find("setmiddle").GetComponent<Transform>().position;
        }

        


        if (other.gameObject.name == "extraGravity")
        {

            extragravity = true;
            
        }

        if (other.gameObject.tag == "resetidle")
        {
            anim.ResetTrigger("gotoidle");
        }



        if (other.gameObject.tag == "unfreeze")
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX
               & ~RigidbodyConstraints.FreezePositionZ;
        }



    }




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LargeFanCrouch"  )
        {
            anim.SetTrigger("crouch");
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running") )
            {
                foreach (Collider box in LargeFancolliders)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, true);
                }
           
           
            }
            else
            {
                foreach (Collider box in LargeFancolliders)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, false);
                }
            }

        }


        if (other.gameObject.tag == "hotdogCrouch")
        {
            anim.SetTrigger("crouch");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {

                Physics.IgnoreCollision(GetComponent<BoxCollider>(), hotdog, true);

            }
            else
            {


                Physics.IgnoreCollision(GetComponent<BoxCollider>(), hotdog, false);


            }

        }


        if (other.gameObject.tag == "windowsCrouch")
        {
            anim.SetTrigger("crouch");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {
                foreach (Collider box in windows)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, true);
                }


            }
            else
            {
                foreach (Collider box in windows)
                {
                    Physics.IgnoreCollision(GetComponent<BoxCollider>(), box, false);
                }
            }

        }

        if (other.gameObject.tag == "ferris")
        {
            IsGrounded = true;
        }


      
        if (other.gameObject.tag == "SideView")
        {

            if (!GameManager.instance.win)
            Camera.main.GetComponent<CameraFollow>().sideview = true;

            Camera.main.GetComponent<CameraFollow>().frontview = false;
            Camera.main.GetComponent<CameraFollow>().view3 = false;
       
        }
       
        if (other.gameObject.tag == "view3")
        {
       
            Camera.main.GetComponent<CameraFollow>().sideview = false;
            Camera.main.GetComponent<CameraFollow>().frontview = false;

            if (!GameManager.instance.win)
                Camera.main.GetComponent<CameraFollow>().view3 = true;
       
        }


    }




    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.tag == "LargeFanCrouch" || other.gameObject.tag == "hotdogCrouch" ||
            other.gameObject.tag == "windowsCrouch" )
        {
            if (!IsPlayerMoving && !anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {
                anim.SetTrigger("idle");
            }
            else
            {
                anim.ResetTrigger("crouch");
            }

           


        }


        if (other.gameObject.tag == "SideView")
        {
            Camera.main.GetComponent<CameraFollow>().sideview = false;

           
            Camera.main.GetComponent<CameraFollow>().frontview = true;

            Camera.main.GetComponent<CameraFollow>().view3 = false;


        }

        if (other.gameObject.tag == "view3")
        {

            Camera.main.GetComponent<CameraFollow>().sideview = false;

           
            Camera.main.GetComponent<CameraFollow>().frontview = true;

            Camera.main.GetComponent<CameraFollow>().view3 = false;

        }



        if (other.gameObject.tag == "slide")
        {
            slide = false;
            if (IsPlayerMoving)
            {
                anim.SetTrigger("run");
            }
            else
            {
                anim.SetTrigger("stop");
            }
           
           
            canMove = true ;

        }

       

        if (other.gameObject.tag == "checkpoint")
        {
           // unfreezeposition();

           
        }


        //  if (other.gameObject.tag == "sideplatform")
        //  {
        //      rb.constraints &= RigidbodyConstraints.FreezePositionX
        //    | RigidbodyConstraints.FreezePositionZ;
        //  }
        //
        //  if (other.gameObject.tag == "unfreeze")
        //  {
        //      rb.constraints &= RigidbodyConstraints.FreezePositionX
        //    | RigidbodyConstraints.FreezePositionZ;
        //  }


        if (other.gameObject.name == "extraGravity")
        {

            extragravity = false;

        }

        if (other.gameObject.tag == "unfreeze")
        {
          
            rb.constraints = RigidbodyConstraints.FreezePositionX
              | RigidbodyConstraints.FreezePositionZ
           | RigidbodyConstraints.FreezeRotation;

        }




    }


    public void Enemy()
    {


        SoundManager.instance.VibrateSwitch();
        GameManager.instance.gameover = true;
        dead = true;
        

        anim.SetTrigger("gotoidle");
        anim.ResetTrigger("jump");

        Camera.main.GetComponent<CameraFollow>().target = null;

        canMove = false;

        rb.isKinematic = true;
        anim.enabled = false;
        playerCollider.enabled = false;
        Invoke("RestartState", 2.1f);
        Invoke("enableCollider", 1.97f);


    }



    private void OnCollisionEnter(Collision col)
    {
        IsGrounded = true;

       


        if (col.gameObject.tag == "leftcorner")
        {

            leftrotate = true;

        }
        if (col.gameObject.tag == "rightcorner")
        {

            rightrotate = true;

        }

        

        if (col.gameObject.tag == "Enemy")
        {
          
       
       
            
               
                SoundManager.instance.VibrateSwitch();
                GameManager.instance.gameover = true;
                dead = true;
                
              
            

                anim.SetTrigger("gotoidle");
                anim.ResetTrigger("jump");
             
                Camera.main.GetComponent<CameraFollow>().target = null;
           
                canMove = false;
           
                rb.isKinematic = true;
                anim.enabled = false;
                playerCollider.enabled = false;
                Invoke("RestartState", 2.1f);
                Invoke("enableCollider", 1.97f);
           
               
            
                                                                  
        }
        

            if (col.gameObject.tag == "climb")
            {
                climb = true;
               // rb.constraints = RigidbodyConstraints.FreezePositionY;
           
            }


            // Print how many points are colliding with this transform
            // Debug.Log("Points colliding: " + col.contacts.Length);

            // Print the normal of the first point in the collision.
            //  Debug.Log("Normal of the first point: " + col.contacts[0].normal);

            //  Draw a different colored ray for every normal in the collision
            // foreach (var item in col.contacts)
            // {
            //     Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            // }
      
    }



    private void OnCollisionStay(Collision col)
    {
        IsGrounded = true;


        if (col.gameObject.tag == "climb")
        {
            climb = true;
           
        }

        if (col.gameObject.tag == "leftcorner")
        {
      
            leftrotate = true;
      
        }
        if (col.gameObject.tag == "rightcorner")
        {
      
            rightrotate = true;
      
        }


    }



    public void OnCollisionExit(Collision col )
    {
        IsGrounded = false;

        if (col.gameObject.tag == "leftcorner")
        {

            leftrotate = false;
      
        }
        if (col.gameObject.tag == "rightcorner")
        {

            rightrotate = false;

           
        }


        if (col.gameObject.tag == "climb" )
        {

            
            rb.useGravity = true;

           // Invoke("unfreezeposition", 0.2f);

            anim.SetFloat("climbSpeed", 0f);

            if (climb)
            {

                climb = false;
                if (IsPlayerMoving)
                {
                    anim.SetTrigger("run");
                }
                else
                {
                    anim.SetTrigger("stop");
                }
                


            }
        }

       
       
       
       


    }




}
