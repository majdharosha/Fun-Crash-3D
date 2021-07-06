using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance  ; 

    public static int[,] shopItems = new int[14, 14];
    public Text ShopcoinsText;
    RewardSystem rewardsystem;
    public static GameObject buttonRef;
    public static int currentPlayer ;
    public static int  bluesold , pinksold,greensold,yellowsold,orangesold , hatsold,glasssold,mustachesold,
      santahatsold, bluegreensold,linessold,pinkbluesold,orangebrownsold ;
   
    private void Awake()
    {
       
        bluesold = PlayerPrefs.GetInt("blueitem");
        pinksold = PlayerPrefs.GetInt("pinkitem");
        greensold = PlayerPrefs.GetInt("greenitem");
        yellowsold = PlayerPrefs.GetInt("yellowitem");
        orangesold = PlayerPrefs.GetInt("orangeitem");
        glasssold  = PlayerPrefs.GetInt("glassitem");
        mustachesold = PlayerPrefs.GetInt("mustacheitem");
        santahatsold = PlayerPrefs.GetInt("santahatitem");
        bluegreensold = PlayerPrefs.GetInt("bluegreenitem");
        linessold = PlayerPrefs.GetInt("linesitem");
        pinkbluesold = PlayerPrefs.GetInt("pinkblueitem");
        orangebrownsold = PlayerPrefs.GetInt("orangebrownitem");
        hatsold = PlayerPrefs.GetInt("hatitem");

       
            buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
       
       
        currentPlayer = PlayerPrefs.GetInt("playerstyle");


      
      
            instance = this;
        
       
        

       
        


        rewardsystem = FindObjectOfType<RewardSystem>();
        


    }




    void Start()
    {

      
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
        
       




        //IDs 
        shopItems[1, 0] = 0;
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;
        shopItems[1, 10] = 10;
        shopItems[1, 11] = 11;
        shopItems[1, 12] = 12;
        shopItems[1, 13] = 13;




        //price 
        
        shopItems[2, 1] = 250;
        shopItems[2, 2] = 250;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 400;
        shopItems[2, 5] = 400;
        shopItems[2, 6] = 600;
        shopItems[2, 7] = 600;
        shopItems[2, 8] = 950;
        shopItems[2, 9] = 950;
        shopItems[2, 10] = 1200;
        shopItems[2, 11] = 1500;
        shopItems[2, 12] = 1500;
        shopItems[2, 13] = 1500;






    }

    private void Update()
    {

       
         buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        



        bluesold = PlayerPrefs.GetInt("blueitem");
        pinksold = PlayerPrefs.GetInt("pinkitem");
        greensold = PlayerPrefs.GetInt("greenitem");
        yellowsold = PlayerPrefs.GetInt("yellowitem");
        orangesold = PlayerPrefs.GetInt("orangeitem");
        glasssold = PlayerPrefs.GetInt("glassitem");
        mustachesold = PlayerPrefs.GetInt("mustacheitem");
        santahatsold = PlayerPrefs.GetInt("santahatitem");
        bluegreensold = PlayerPrefs.GetInt("bluegreenitem");
        linessold = PlayerPrefs.GetInt("linesitem");
        pinkbluesold = PlayerPrefs.GetInt("pinkblueitem");
        orangebrownsold = PlayerPrefs.GetInt("orangebrownitem");
        hatsold = PlayerPrefs.GetInt("hatitem");


    }

  

    public void RedCurrentPlayer()
    {
        currentPlayer = 0;
 
        PlayerPrefs.SetInt("playerstyle", currentPlayer);
        
    }


    public void BuyBlue()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
       

        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && bluesold == 0 )
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 1;
            RewardSystem.instance.SaveCoins();

            PlayerPrefs.SetInt("blueitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer); 
           

           
          //  buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          //  buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false); 
        }

       
        


    }

    public void blueCurrentPlayer()
    {
        currentPlayer = 1;
        if (bluesold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void BuyPink()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && pinksold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 2;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("pinkitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
            

           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }
    


    }

    public void pinkCurrentPlayer ()
    {
        currentPlayer = 2;
        if (pinksold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void Buygreen()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && greensold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 3;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("greenitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void greenCurrentPlayer()
    {
        currentPlayer = 3;
        if (greensold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void BuyOrange  ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && orangesold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 4;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("orangeitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void OrangeCurrentPlayer()
    {
        currentPlayer = 4;
        if (orangesold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void BuyYellow ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && yellowsold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 5;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("yellowitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


          // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void yellowCurrentPlayer()
    {
        currentPlayer = 5;
        if (yellowsold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void Buyblueandgreen ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && bluegreensold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 6;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("bluegreenitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


          // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void BlueGreenCurrentPlayer()
    {
        currentPlayer = 6;
        if (bluegreensold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }



    public void BuyLinesk()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && linessold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 7;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("linesitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void LinesCurrentPlayer()
    {
        currentPlayer = 7;
        if (linessold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void BuyPinkBlue ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && pinkbluesold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 8;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("pinkblueitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


          //  buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          //  buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void pinkBlueCurrentPlayer()
    {
        currentPlayer = 8;
        if (pinkbluesold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }

    public void BuyOrangeBrown ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && orangebrownsold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 9;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("orangebrownitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void OrangeBrownCurrentPlayer()
    {
        currentPlayer = 9;
        if (orangebrownsold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }




    public void BuyHat ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && hatsold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 10;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("hatitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
           

           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }
       


    }



    public void hatCurrentPlayer()
    {
        currentPlayer = 10;
        if (hatsold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }



    public void BuyGlasses ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && glasssold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 11;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("glassitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


          //  buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          //  buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void GlassesCurrentPlayer()
    {
        currentPlayer = 11;
        if (glasssold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }


    public void BuyMustache ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && mustachesold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 12;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("mustacheitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


          // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
          // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void MustacheCurrentPlayer()
    {
        currentPlayer = 12;
        if (mustachesold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }

    public void BuySantaHat ()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


        if (rewardsystem.coinScore >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID] && santahatsold == 0)
        {

            rewardsystem.coinScore -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            ShopcoinsText.text = rewardsystem.coinScore.ToString();
            currentPlayer = 13;
            RewardSystem.instance.SaveCoins();
            PlayerPrefs.SetInt("santahatitem", 1);
            PlayerPrefs.SetInt("playerstyle", currentPlayer);


           // buttonRef.GetComponent<ButtonInfo>().pricetxt.gameObject.SetActive(false);
           // buttonRef.GetComponent<ButtonInfo>().coinImage.gameObject.SetActive(false);



        }



    }

    public void SantaCurrentPlayer()
    {
        currentPlayer = 13;
        if (santahatsold == 1)
        {
            PlayerPrefs.SetInt("playerstyle", currentPlayer);
        }
    }

}
