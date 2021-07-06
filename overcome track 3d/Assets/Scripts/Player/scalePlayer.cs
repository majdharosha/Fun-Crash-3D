using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalePlayer : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        float screensize = Screen.width + Screen.height;
        float dimension = screensize / 28;
        float PreviewSize = dimension * 0.01f;

        if (Screen.width + Screen.height <= 1000)
            return;
       

        transform.localScale = new Vector3(PreviewSize, PreviewSize, PreviewSize);

    }
}
