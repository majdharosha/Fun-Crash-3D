using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ButtonInfo : MonoBehaviour
{
    public static ButtonInfo instance; 

    public int ItemID;
    public Text pricetxt;
    public Text iteminuse;
    public Image coinImage;
    public Text Use;
    PlayerStyle playerstyle; 

    public static int CurrentIteminUse ; 
    private void Awake()
    {
        instance = this; 

        CurrentIteminUse = PlayerPrefs.GetInt("playerstyle");
        playerstyle = FindObjectOfType<PlayerStyle>();
        
    }
    private void Start()
    {

        CurrentIteminUse = PlayerPrefs.GetInt("playerstyle");

        RedInUse();
        blueBought();
        pinkBought();
        greenBought();
        orangeBought();
        yellowBought();
        bluegreenBought();
        linesBought();
        pinkblueBought();
        orangebrownBought();
        hatbought();
        glassbought();
        mustachebought();
        santabought();
    }


    void Update()
    {

        if (pricetxt != null)
        {
            pricetxt.text = ShopManager.shopItems[2, ItemID].ToString();
        }
       

        CurrentIteminUse = PlayerPrefs.GetInt("playerstyle");
       

        RedInUse();
        blueBought();
        pinkBought();
        greenBought();
        orangeBought();
        yellowBought();
        bluegreenBought();
        linesBought();
        pinkblueBought();
        orangebrownBought();
        hatbought();
        glassbought();
        mustachebought();
        santabought();

       
    }




    void RedInUse()
    {

        if ( ItemID == 0)
        {
          

            if ( CurrentIteminUse == 0)
            {
                iteminuse.gameObject.SetActive(true);
                Use.gameObject.SetActive(false);
            }

            else
            {
                Use.gameObject.SetActive(true);
                iteminuse.gameObject.SetActive(false);
            }


        }
    }



    void blueBought()
    {

        if (ShopManager.bluesold == 1 && ItemID == 1)
        {
           
                               
            try
            {
                pricetxt.gameObject.SetActive(false);
                coinImage.gameObject.SetActive(false);

                if (CurrentIteminUse == 1)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }

                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }



            
             

        }
    }

    void pinkBought()
    {

        if (ShopManager.pinksold == 1 && ItemID == 2)
        {


            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 2)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }


           
                

        }
    }

    void greenBought()
    {

        if (ShopManager.greensold == 1 && ItemID == 3)
        {

            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 3)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }

           


        }
    }

    void orangeBought()
    {

        if (ShopManager.orangesold == 1 && ItemID == 4)
        {

            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 4)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }

           


        }
    }

    void yellowBought()
    {

        if (ShopManager.yellowsold == 1 && ItemID == 5)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 5)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }
           


        }
    }

    void bluegreenBought()
    {

        if (ShopManager.bluegreensold == 1 && ItemID == 6)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 6)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }


    void linesBought()
    {

        if (ShopManager.linessold == 1 && ItemID == 7)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 7)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }

    void pinkblueBought()
    {

        if (ShopManager.pinkbluesold == 1 && ItemID == 8)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 8)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }

    void orangebrownBought()
    {

        if (ShopManager.orangebrownsold == 1 && ItemID == 9)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 9)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);
                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }

   

    void hatbought ()
    {
        if (ShopManager.currentPlayer == 10)
        {
            playerstyle.itemactivated[10].SetActive(true);
        }
        else
        {
            playerstyle.itemactivated[10].SetActive(false);
        }

        if (ShopManager.hatsold == 1 && ItemID == 10)
        {

            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 10)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);

                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);

                }
            }
            catch (NullReferenceException e)
            {

            }
           


        }
    }

    void glassbought()
    {
        if (ShopManager.currentPlayer == 11)
        {
           playerstyle.itemactivated[11].SetActive(true);
        }
        else
        {
            playerstyle.itemactivated[11].SetActive(false);
        }


        if (ShopManager.glasssold== 1 && ItemID == 11)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 11)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);

                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);

                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }


    void mustachebought()
    {

        if (ShopManager.currentPlayer == 12)
        {
            playerstyle.itemactivated[12].SetActive(true);
        }
        else
        {
            playerstyle.itemactivated[12].SetActive(false);
        }
       
        if (ShopManager.mustachesold== 1 && ItemID == 12)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 12)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);

                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);

                }
            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }



    void santabought()
    {
        if (ShopManager.currentPlayer == 13)
        {
            playerstyle.itemactivated[13].SetActive(true);
        }
        else
        {
            playerstyle.itemactivated[13].SetActive(false);
        }


        if (ShopManager.santahatsold == 1 && ItemID == 13)
        {
            try
            {
                coinImage.gameObject.SetActive(false);
                pricetxt.gameObject.SetActive(false);

                if (CurrentIteminUse == 13)
                {
                    iteminuse.gameObject.SetActive(true);
                    Use.gameObject.SetActive(false);

                }
                else
                {
                    Use.gameObject.SetActive(true);
                    iteminuse.gameObject.SetActive(false);

                }

            }
            catch (NullReferenceException e)
            {

            }
            


        }
    }















}
