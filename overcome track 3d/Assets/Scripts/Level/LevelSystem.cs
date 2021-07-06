using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance; 
    public static  GameObject currentcheckpoint;
    Transform playert;
    int levelnumber ;
    Rigidbody rb;
    public GameObject player; 
    public int level ;
    public bool lastcheckpoint = false ;
   

   
    private void Awake()
    {
        
        rb =  player.GetComponent<Rigidbody>();
        levelnumber = PlayerPrefs.GetInt("Level", 1);
          instance = this;     
    }

 


    void Start()
    {
        playert = player.transform;

      
    }

    void  LateUpdate()
    {




    }

   

    public void Finish()
    {
        GameUI.instance.finishUI.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
       
    }
    
    public void SaveLevel()
    {
       // SaveSystem.playerSave(this);
    }

    public void StoreMenu()
    {
        SceneManager.LoadScene("Store");

    }


    public void LoadLevel()
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
       // PlayerPrefs.SetInt("Playerstyle", ShopManager.instance.currentPlayer);

        //  LevelSave data = SaveSystem.loadplayer();
        //  level = data.level;
        // SceneManager.LoadSceneAsync(level);
    }

    
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameUI.instance.finishUI.SetActive(false);

    }

    public void LoadFirstLevel ()
    {

        SceneManager.LoadScene("Level 1");
        GameUI.instance.finishUI.SetActive(false);
        PlayerPrefs.DeleteAll();
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }




}
