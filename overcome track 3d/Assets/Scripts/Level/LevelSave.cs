using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelSave 
{

    public int level;
    public  int coinScore;

    public LevelSave (RewardSystem rewardsystem)
    {
        // level = levelsystem.level;
        coinScore = rewardsystem.coinScore;

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


}
