using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
    }
}
