using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerStyle : MonoBehaviour
{

    private SkinnedMeshRenderer playerstyle;
    public Material[] color;
    public  GameObject[] itemactivated ;
   
 
    private void Awake()
    {
        playerstyle = GameObject.Find("Stickman_Player").GetComponent<SkinnedMeshRenderer>();
      
        playerstyle.material = color[PlayerPrefs.GetInt("playerstyle")];

        


    }
    void Start()
    {
       
        
    }

    void Update()
    {

     
         
         playerstyle.material = color[ShopManager.currentPlayer];



    }


    void hatbought()
    {
        if (ShopManager.hatsold == 1 )
        {

          // for Player

           // if (CurrentIteminUse == 10)
           // {
           //    
           //     itemactivated[10].SetActive(true);
           // }
           // else
           // {
           //    
           //     itemactivated[10].SetActive(false);
           // }


        }
    }

}
