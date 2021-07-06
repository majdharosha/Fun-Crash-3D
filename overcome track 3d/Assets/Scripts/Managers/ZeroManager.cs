using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start  ()
    {
       // Invoke("loading", 0.1f);
        loading();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loading()
    {
        SceneManager.LoadSceneAsync (PlayerPrefs.GetInt("Level", 1));
    }
}
