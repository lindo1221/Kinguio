using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    public GameObject Poder;
    public float tempo = 1.5f;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }

    public void timer() 
    {
       tempo -= Time.deltaTime;

        if(tempo <= 0) 
        {
            Object.Destroy(Poder);
        }
    }

  
}
