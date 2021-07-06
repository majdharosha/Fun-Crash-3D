using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    private AudioSource audiosource ;
    public bool sound = true, vibrate = true;
    public Player player;
    string soundswitch , vibrateswitch ;

    void Awake ()
    {

        instance = this; 
        audiosource = GetComponent<AudioSource>();
        player.GetComponent<Player>();

       


    }

    private void Start()
    {
        if (PlayerPrefs.GetString("soundButton") == "soundon")
        {
            sound = true;
        }
        else if (PlayerPrefs.GetString("soundButton") == "soundoff")
        {
            sound = false;
        }



        if (PlayerPrefs.GetString("vibrate") == "vibrateon")
        {
            vibrate = true;
        }
        else if (PlayerPrefs.GetString("vibrate") == "vibrateoff")
        {
            vibrate = false;
        }


    }




    private void Update()
    {
        PlaySoundFX();

       
            
        


        if (sound)
        {
            soundswitch = "soundon";
        }
        else
        {
            soundswitch = "soundoff";
        }

        PlayerPrefs.SetString("soundButton", soundswitch);


        if (vibrate)
        {
            vibrateswitch = "vibrateon";
        }
        else
        {
            vibrateswitch = "vibrateoff";
        }

        PlayerPrefs.SetString("vibrate", vibrateswitch);


    }

    public void SoundOnOff ()
    {
        sound = !sound; 
    }

    public void VibrateOnOff()
    {
        vibrate = !vibrate;
    }
  


    public void PlaySoundFX()
    {
        if (sound )
        {
            if (player.playerstate == Player.PlayerState.Finish)
            {
                audiosource.PlayOneShot(audiosource.clip, 0.5f);
            }
            

        }

    }

    public void VibrateSwitch()
    {
        if (vibrate)
        {

            Handheld.Vibrate();

        }

    }

}
