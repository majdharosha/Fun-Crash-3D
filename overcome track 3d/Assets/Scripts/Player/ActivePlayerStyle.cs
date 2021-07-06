using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerStyle : MonoBehaviour
{
    private SkinnedMeshRenderer playerstyle;
    public Material[] color;
    public GameObject[] itemactivated;
    int currentitem; 

    private void Awake()
    {
        playerstyle = GameObject.Find("Stickman_Player").GetComponent<SkinnedMeshRenderer>();

        playerstyle.material = color[PlayerPrefs.GetInt("playerstyle")];




    }
    void Start()
    {
        hatbought();
        glassesbought();
        mustachebought();
        santabought();
        currentitem = PlayerPrefs.GetInt("playerstyle");
    }

    void Update()
    {
        hatbought();
        glassesbought();
        mustachebought();
        santabought();
    }


    void hatbought()
    {
        if (PlayerPrefs.GetInt("hatitem") == 1)
        {

             

             if (currentitem == 10)
             {
                
                 itemactivated[10].SetActive(true);
             }
             else
             {
                
                 itemactivated[10].SetActive(false);
             }


        }
    }

    void glassesbought()
    {
        if (PlayerPrefs.GetInt("glassitem") == 1)
        {



            if (currentitem == 11)
            {

                itemactivated[11].SetActive(true);
            }
            else
            {

                itemactivated[11].SetActive(false);
            }


        }
    }

    void mustachebought()
    {
        if (PlayerPrefs.GetInt("mustacheitem") == 1)
        {



            if (currentitem == 12)
            {

                itemactivated[12].SetActive(true);
            }
            else
            {

                itemactivated[12].SetActive(false);
            }


        }
    }

    void santabought()
    {
        if (PlayerPrefs.GetInt("santahatitem") == 1)
        {



            if (currentitem == 13)
            {

                itemactivated[13].SetActive(true);
            }
            else
            {

                itemactivated[13].SetActive(false);
            }


        }
    }
}
