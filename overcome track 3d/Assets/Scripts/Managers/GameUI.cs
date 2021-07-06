using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{

    public static GameUI instance;
    public GameObject homeUI, inGameUI,finishUI, gameOverUI;
    public GameObject allbtns, finishLine;
    public Text currentleveltxt, nextleveltxt , coinsText, coinsTextFinishUI , timertext;
    bool btns;

    public Text ClevelFinish, NlevelFinish , ClevelHome, NlevelHome, bonuscoins;
    [Header("InGame")]
    public Image levelSlider;
  
    float startdistance, distance;
    int level;

    public GameObject loadnextbtn, rewardbtn, playagainbtn, congrats; 
    public Player player;

    public Button soundbtn, vibratebtn;
    public Sprite soundOnspr, soundOffspr ;
    RewardSystem rewardsystem; 

    void Awake ()
    {

         instance = this;




        gameOverUI.SetActive(false);

        rewardsystem = FindObjectOfType<RewardSystem>();
        startdistance = Vector3.Distance(player.transform.position,finishLine.transform.position);


        player.GetComponent<Player>();
        soundbtn.onClick.AddListener(() => SoundManager.instance.SoundOnOff());
        vibratebtn.onClick.AddListener(() => SoundManager.instance.VibrateOnOff());


    }

    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if (currentleveltxt != null)
        currentleveltxt.text = level.ToString();
        if (nextleveltxt != null)
        nextleveltxt.text = level + 1 + "";
        coinsText.text = rewardsystem.coinScore.ToString();


        ClevelHome.text = currentleveltxt.text;
        NlevelHome.text = nextleveltxt.text;

        ClevelFinish.text = currentleveltxt.text;
        NlevelFinish.text = nextleveltxt.text;


        try
        {
          
            if (SideLevel.instance == null)
            {
                bonuscoins.gameObject.SetActive(false);
            }
            else
            {
                bonuscoins.gameObject.SetActive(true);
            }


        }
        catch (NullReferenceException e)
        {

        }

        
        if (SceneManager.GetActiveScene().name == "Level50")
        {
            loadnextbtn.SetActive(false);
            rewardbtn.SetActive(false);
            playagainbtn.SetActive(true);
            congrats.SetActive(true);
        }
        else
        {
            loadnextbtn.SetActive(true);
            rewardbtn.SetActive(true);
            playagainbtn.SetActive(false);
            congrats.SetActive(false);
        }
          



    }

    void Update()
    {


      
        if (player.playerstate == Player.PlayerState.Prepare)
        {
            
            if (SoundManager.instance.sound && soundbtn.GetComponent<Image>().sprite != soundOnspr)
                soundbtn.GetComponent<Image>().sprite = soundOnspr;
            else if (!SoundManager.instance.sound && soundbtn.GetComponent<Image>().sprite != soundOffspr )
                soundbtn.GetComponent<Image>().sprite = soundOffspr;


            if (SoundManager.instance.vibrate && vibratebtn.GetComponent<Image>().color != new Color(1, 1, 1, 1f))
                vibratebtn.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            else if (!SoundManager.instance.vibrate && vibratebtn.GetComponent<Image>().color != new Color(1, 1, 1, 0.4f))
                vibratebtn.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);


        }

        if (Input.GetMouseButtonDown(0) && !IgnoreUI() && player.playerstate == Player.PlayerState.Prepare)
        {
          
            player.playerstate = Player.PlayerState.Playing;
            homeUI.SetActive(false);
            inGameUI.SetActive(true);
            Player.instance.canMove = true;
            GameManager.instance.startTime = true;
        }


        distance = Vector3.Distance(player.transform.position, finishLine.transform.position);
        if (player.transform.position.z < finishLine.transform.position.z)
            levelSlider.fillAmount = 1 - distance / startdistance;


        if (SceneManager.GetActiveScene().name != "Level 1")
        {
            ClevelFinish.text = currentleveltxt.text;
            NlevelFinish.text = nextleveltxt.text;
        }
        

    }

    public void SliderFill (float fillamount)
    {
        levelSlider.fillAmount = fillamount; 
    }

    public void Settings ()
    {
        btns = !btns;
        allbtns.SetActive(btns); 
    }


    public bool IgnoreUI ()
    {
        PointerEventData pointereventdata = new PointerEventData(EventSystem.current);
        pointereventdata.position = Input.mousePosition;

        List<RaycastResult> raycastresult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointereventdata, raycastresult);

        for (int i =0; i < raycastresult.Count; i++)
        {
            if (raycastresult[i].gameObject.GetComponent<IgnoreUI>() != null)
            {
                raycastresult.RemoveAt(i);

                i--;
            }
        }

        return  raycastresult.Count > 0; 
    }


 


}
