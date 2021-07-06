using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;
using UnityEngine.SceneManagement;

public class LevelLogging : MonoBehaviour
{
  
    int sceneindex;
    string scenename;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {

        var activescene = SceneManager.GetActiveScene();
        sceneindex = activescene.buildIndex;
        scenename = activescene.name;




      
  



        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventScreenView);
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAppOpen);


                       Firebase.Analytics.FirebaseAnalytics.LogEvent(
               Firebase.Analytics.FirebaseAnalytics.EventLevelStart,
               new Firebase.Analytics.Parameter(
                 Firebase.Analytics.FirebaseAnalytics.ParameterLevel, sceneindex),
               new Firebase.Analytics.Parameter(
                 Firebase.Analytics.FirebaseAnalytics.ParameterLevelName, scenename)
               );




    }



    private void OnDestroy()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
         Firebase.Analytics.FirebaseAnalytics.EventLevelEnd,
         new Firebase.Analytics.Parameter(
           Firebase.Analytics.FirebaseAnalytics.ParameterLevel, sceneindex),
         new Firebase.Analytics.Parameter(
           Firebase.Analytics.FirebaseAnalytics.ParameterLevelName, scenename)
         );




    }
}
