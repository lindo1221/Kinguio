using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBugAgua : MonoBehaviour
{
    public float tempo = 100f;
    public GameObject ataque;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true) 
        {
          tempo -= Time.time;
        }
        if (tempo <= 0)
        {
          Object.Destroy( ataque );
         
        }
    }

   
}
