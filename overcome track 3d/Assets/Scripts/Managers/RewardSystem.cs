using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class RewardSystem : MonoBehaviour
{
     

    public static RewardSystem instance;  
    public  int coinScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        
              
    }

    void Start()
    {
        LoadCoins();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            File.Delete(Application.persistentDataPath + "/player.data");
           // UnityEditor.AssetDatabase.Refresh();
        }

        if (Player.instance.playerstate == Player.PlayerState.Finish)
        {
            SaveCoins();
        }


    }


    public void CoinIncrement()
    {
        coinScore += 10;



        if (SceneManager.GetActiveScene().name != "Store")
        {
            GameUI.instance.coinsText.text = coinScore.ToString();
            GameUI.instance.coinsTextFinishUI.text = coinScore.ToString();
        }


        if (SceneManager.GetActiveScene().name == "Store")
        {
            ShopManager.instance.ShopcoinsText.text = coinScore.ToString();
        }





    }

    public void FinishReward()
    {
        coinScore += 100;
       

        if (SceneManager.GetActiveScene().name != "Store")
        {
            GameUI.instance.coinsText.text = coinScore.ToString();
            GameUI.instance.coinsTextFinishUI.text = coinScore.ToString();
        }

        if (SceneManager.GetActiveScene().name == "Store")
        {
            ShopManager.instance.ShopcoinsText.text = coinScore.ToString();
        }


    }

    public void RewardVideo ()
    {
        coinScore += 200;
        

        if (SceneManager.GetActiveScene().name != "Store")
        {
            GameUI.instance.coinsText.text = coinScore.ToString();
            GameUI.instance.coinsTextFinishUI.text = coinScore.ToString();
        }

        if (SceneManager.GetActiveScene().name == "Store")
        {
            ShopManager.instance.ShopcoinsText.text = coinScore.ToString();
        }


    }




    public void OnTriggerEnter(Collider target)
    {
        if (target.tag == "coin")
        {
            Destroy(target.gameObject);
            CoinIncrement();
         
        }

        if (target.gameObject.tag == "Finish")
        {
            FinishReward();
        }

    }


    public void SaveCoins()
    {
        SaveSystem.playerSave(this);
    }

    public void LoadCoins()
    {
         LevelSave data = SaveSystem.loadplayer(this);
         coinScore = data.coinScore;


        if (SceneManager.GetActiveScene().name != "Store")
        {
            GameUI.instance.coinsText.text = coinScore.ToString();
            GameUI.instance.coinsTextFinishUI.text = coinScore.ToString();
        }


        try
        {
            ShopManager.instance.ShopcoinsText.text = coinScore.ToString();
        }
        catch (NullReferenceException e)
        {

        }
        
    }


   // void OnApplicationQuit()
   // {
   //     SaveCoins();
   // }





}
