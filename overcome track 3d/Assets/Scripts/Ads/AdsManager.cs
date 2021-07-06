using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    #if UNITY_IOS
            private string gameId = "4100600";
    #elif UNITY_ANDROID
        private string gameId = "4100601";
#endif

    public static AdsManager adsmanager;
    bool testMode = false;
    public string RewardedId = "rewardedVideo";

    public string interstitialId = "Interstitial";

    public string shortId = "interstitialshort";

    public string fiveSecondsId = "5seconds";

    public string skipId = "video";
    public bool noadsPurchased = false;

    void Awake()
    {
        adsmanager = this;
        SetupAds();
    }


    void Start()
    {
        
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        AnalyticsforAds();

    }

 
    public void ShowInterstitialAd ()
    {
           
        if (SceneManager.GetActiveScene().buildIndex == 7
            || SceneManager.GetActiveScene().buildIndex == 11
            || SceneManager.GetActiveScene().buildIndex == 15
            || SceneManager.GetActiveScene().buildIndex == 19
            || SceneManager.GetActiveScene().buildIndex == 23
            || SceneManager.GetActiveScene().buildIndex == 27
            || SceneManager.GetActiveScene().buildIndex == 31
            || SceneManager.GetActiveScene().buildIndex == 35
            || SceneManager.GetActiveScene().buildIndex == 38
            || SceneManager.GetActiveScene().buildIndex == 41
            || SceneManager.GetActiveScene().buildIndex == 44
            || SceneManager.GetActiveScene().buildIndex == 47            
            || SceneManager.GetActiveScene().buildIndex == 49
            )
        {
            ShowlongAd();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 13
            || SceneManager.GetActiveScene().buildIndex == 17
            || SceneManager.GetActiveScene().buildIndex == 21
            || SceneManager.GetActiveScene().buildIndex == 25
            || SceneManager.GetActiveScene().buildIndex == 29
            || SceneManager.GetActiveScene().buildIndex == 33
            || SceneManager.GetActiveScene().buildIndex == 37
            || SceneManager.GetActiveScene().buildIndex == 40
            || SceneManager.GetActiveScene().buildIndex == 43
            || SceneManager.GetActiveScene().buildIndex == 46
                                                              )
        {          
            ShowshortAd(); 
        }


        else
        {
            seconds5Ad();
        }
    }

    public void ShowlongAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (!noadsPurchased)
        {

            if (Advertisement.IsReady(interstitialId))
            {
                Advertisement.Show(interstitialId);
  
            }
            else
            {
                Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            }

        }
    }

    public void ShowshortAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (!noadsPurchased)
        {

            if (Advertisement.IsReady(shortId))
            {
                Advertisement.Show(shortId);
            }
            else
            {
                Debug.Log("short ad not ready at the moment! Please try again later!");
            }

        }
    }

    public void seconds5Ad()
    {
        // Check if UnityAds ready before calling Show method:
        if (!noadsPurchased)
        {

            if (Advertisement.IsReady(fiveSecondsId))
            {
                Advertisement.Show(fiveSecondsId);
            }
            else
            {
                Debug.Log("short ad not ready at the moment! Please try again later!");
            }

        }
    }



    public void SkipAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (!noadsPurchased)
        {
            if (Advertisement.IsReady(skipId))
            {
                Advertisement.Show(skipId);
            }
            else
            {
                Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            }
        }
        
    }



    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(RewardedId))
        {
            Advertisement.Show(RewardedId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if (surfacingId == RewardedId)
            {
                RewardSystem.instance.RewardVideo();
                RewardSystem.instance.SaveCoins();
            }
            
               

        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == RewardedId)
        {

            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }



    public void SetupAds()
    {
        if (PlayerPrefs.HasKey("AdsRemoved"))
        {
            noadsPurchased = true;
        }
           
        else
        {
            noadsPurchased = false;
        }

        // return;

        
        // Setup your ads here
       

    }


    public void RemoveAds()
    {
        if (PlayerPrefs.HasKey("AdsRemoved"))
        {
            noadsPurchased = true;
            print("Ads already removed");
        }
            
        else
        {
            PlayerPrefs.SetInt("AdsRemoved", 1);
            noadsPurchased = true;
            PlayerPrefs.Save();

            // destroy/disable all your ad objects here
        }

    }


    void RestorePurchases()
    {
       // if (IsProductPurchased("ProductId"))
       //     RemoveAds();
    }


    void AnalyticsforAds()
    {
               AnalyticsResult analyticsresultAd_Start = AnalyticsEvent.Custom("ad_start", new Dictionary<string, object>
           {
               { "SkippableAd_TimeOut", skipId},
               { "interstitalnoskipAd_LevelEnd", interstitialId},
               { "10secondsAd_LevelEnd", shortId},
               { "5secondsAd_LevelEnd", fiveSecondsId},
               { "RewardedAd_RewardedButton", RewardedId},
          
           });
              // Debug.Log("adstart is " + analyticsresultAd_Start);
          
          
               AnalyticsResult analyticsresultAdcomplete = AnalyticsEvent.Custom("ad_complete", new Dictionary<string, object>
           {
                { "SkippableAd_TimeOut", skipId},
               { "interstitalnoskipAd_LevelEnd", interstitialId},
               { "10secondsAd_LevelEnd", shortId},
               { "5secondsAd_LevelEnd", fiveSecondsId},
               { "RewardedAd_RewardedButton", RewardedId},
          
           });
              
          
          
          
          
             AnalyticsResult analyticsresultAdOffer  = AnalyticsEvent.Custom("ad_offer", new Dictionary<string, object>
         {
              { "SkippableAd_TimeOut", "video"},
             { "interstitalnoskipAd_LevelEnd", "Interstitial"},
             { "10secondsAd_LevelEnd", "interstitialshort"},
             { "5secondsAd_LevelEnd", "5seconds"},
             { "RewardedAd_RewardedButton","rewardedVideo"},
       
         });
             


        AnalyticsResult analyticsresultAdpostaction  = AnalyticsEvent.Custom("post_ad_action", new Dictionary<string, object>
         {
              { "SkippableAd_TimeOut", "video"},
             { "interstitalnoskipAd_LevelEnd", "Interstitial"},
             { "10secondsAd_LevelEnd", "interstitialshort"},
             { "5secondsAd_LevelEnd", "5seconds"},
             { "RewardedAd_RewardedButton","rewardedVideo"},

         });
        ;



    }



}
