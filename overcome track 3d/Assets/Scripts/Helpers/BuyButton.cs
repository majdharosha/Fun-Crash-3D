using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour
{

    
    public  GameObject[] buybutton;
    GameObject buttonRef1; 

    private void Awake()
    {
       

    }
    private void Update()
    {

        buttonRef1 = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;


            BlueActive();
            PinkActive();
            greenActive();
            orangeActive();
            yellowActive();
            bluegreenActive();
            linesActive();
            pinkblueActive();
            orangebrownActive();
            hatActive();
            glassActive();
            mustacheActive();
            santaActive();
        
        
    }

    void BlueActive ()
    {

        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 1 && ShopManager.bluesold == 0)
                {

                    buybutton[1].SetActive(true);


                }

                else
                {
                    buybutton[1].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

        



        }

       
    }
  
  
    void PinkActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 2 && ShopManager.pinksold == 0)
                {

                    buybutton[2].SetActive(true);


                }

                else
                {
                    buybutton[2].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }


          
        }



    }
  
  
    void greenActive()
    {
        if (ShopManager.buttonRef != null)
        {


            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 3 && ShopManager.greensold == 0)
                {

                    buybutton[3].SetActive(true);


                }

                else
                {
                    buybutton[3].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

         
        }
       
    }
  
  
    void orangeActive()
    {


        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 4 && ShopManager.orangesold == 0)
                {

                    buybutton[4].SetActive(true);


                }

                else
                {
                    buybutton[4].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

           
        }
       
    }
    void yellowActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 5 && ShopManager.yellowsold == 0)
                {

                    buybutton[5].SetActive(true);


                }

                else
                {
                    buybutton[5].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
      
    }
    void bluegreenActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 6 && ShopManager.bluegreensold == 0)
                {

                    buybutton[6].SetActive(true);


                }

                else
                {
                    buybutton[6].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

            
        }

       
    }
  
    void linesActive()
    {

        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 7 && ShopManager.linessold == 0)
                {

                    buybutton[7].SetActive(true);


                }

                else
                {
                    buybutton[7].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
        
    }
  
    void pinkblueActive()
    {
        if (ShopManager.buttonRef != null)
        {
            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 8 && ShopManager.pinkbluesold == 0)
                {

                    buybutton[8].SetActive(true);


                }

                else
                {
                    buybutton[8].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }


           
        }
        
    }
  
    void orangebrownActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 9 && ShopManager.orangebrownsold == 0)
                {

                    buybutton[9].SetActive(true);


                }

                else
                {
                    buybutton[9].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }


           
        }
       
    }
  
    void hatActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 10 && ShopManager.hatsold == 0)
                {

                    buybutton[10].SetActive(true);


                }

                else
                {
                    buybutton[10].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
       
    }
  
    void glassActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 11 && ShopManager.glasssold == 0)
                {

                    buybutton[11].SetActive(true);


                }

                else
                {
                    buybutton[11].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
        
    }
  
    void mustacheActive()
    {
        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 12 && ShopManager.mustachesold == 0)
                {

                    buybutton[12].SetActive(true);


                }

                else
                {
                    buybutton[12].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
       
    }
  
    void santaActive()
    {

        if (ShopManager.buttonRef != null)
        {

            try
            {
                if (ShopManager.buttonRef.GetComponent<ButtonInfo>().ItemID == 13 && ShopManager.santahatsold == 0)
                {

                    buybutton[13].SetActive(true);


                }

                else
                {
                    buybutton[13].SetActive(false);
                }
            }

            catch (NullReferenceException e)
            {

            }

          
        }
       
    }
  
  
  




}
