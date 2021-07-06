using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; 

public class Banner : MonoBehaviour
{

    string gameId = "4100601";
    bool testMode = false;

    public string surfacingId = "BannerAd";

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);

        if (!AdsManager.adsmanager.noadsPurchased)
        {
            StartCoroutine(ShowBannerWhenInitialized());
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }
        
    }

  


    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surfacingId);
    }


  


}
