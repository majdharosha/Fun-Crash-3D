using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;
using Firebase.Analytics;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameover = false, win = false;
    public GameObject player, finish, checkpoint;
    int level;
    public float timerTime;
    public bool startTime = false;
    public GameObject winEffect;
   

    private void Awake()
    {

        

        instance = this;
      
       
      

        if (finish != null)
            finish = GameObject.Find("Finish");

        


    }

   

    void Start()
    {


        win = false;
       
       
        try
        {
            if (SideLevel.instance == null)
            {
                SideLevel.instance.sideLevel = false;
            }
            else
            {
                SideLevel.instance.sideLevel = true;
            }
        }

        catch (NullReferenceException e)
        {

        }


      

    }

    void Update ()
    {

   

        if (gameover)
        {
            FirebaseAnalytics.LogEvent("PlayerDied", new Parameter("type", "dead"));

           AnalyticsResult analyticsresult = AnalyticsEvent.Custom("Player_Died", new Dictionary<string, object>
    {
        { "deadAtLevel", SceneManager.GetActiveScene().name },
        { "deadAtTime", timerTime }
               
        });


            Invoke("GameOver", 2f);
            gameover = false;
        }

      
        if (startTime)
        {
            CountDown();
        }

    }

   

    void GameOver()
    {
        Vector3 rotation = LevelSystem.currentcheckpoint.transform.eulerAngles;

        player.transform.eulerAngles = rotation;


        try
        {
            Camera.main.GetComponent<CameraFollow>().target = player;
        }
        catch (NullReferenceException e)
        {

        }




        if (Player.instance.canMove == false)
        {

            player.transform.localPosition = new Vector3(LevelSystem.currentcheckpoint.transform.position.x
           , LevelSystem.currentcheckpoint.transform.position.y,
           LevelSystem.currentcheckpoint.transform.position.z);

        }


        Player.instance.canMove = true;
    }

    public void CountDown()
    {
        if (!win)
        {
            timerTime -= Time.deltaTime;
        }
        
       GameUI.instance.timertext.text = "     " + timerTime.ToString("f0");

        if (timerTime <= 0)
        {
            Player.instance.timeactive = false;
            timerTime = 0;          
            GameUI.instance.gameOverUI.SetActive(true);
            
        }
    }



    public void StartWinParticles ()
    {
        GameObject win = Instantiate(winEffect);
        float y = finish.transform.position.y + 5;
        float z = finish.transform.position.z;
        float x = finish.transform.position.x;

        win.transform.position = new Vector3(x, y, z); ;
        win.transform.rotation = Quaternion.identity;

    }

}
