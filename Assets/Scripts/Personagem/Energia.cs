using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energia : MonoBehaviour
{
    public float energiaPower = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (energiaPower > 100) 
        {
            energiaPower = 100;
        }
    }
}
