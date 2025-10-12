using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevarDano : MonoBehaviour
{
    public int vida = 10;
    public Energia energia;
    public bool receberEenrgia = true;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque")) 
        {
            vida--;
        }
        if (collision.gameObject.CompareTag("power"))
        {
            vida -= 5;
            if (vida <= 0) 
            {
             receberEenrgia = false;
            }
        }
    }

    public void Destroy()
    {
        if(vida <= 0 && receberEenrgia) 
        {
         energia.energiaPower += 10;
         Destroy(gameObject);
         receberEenrgia=true;
        }
        else if (vida <= 0 && !receberEenrgia) 
        {
          Destroy(gameObject);
        }



    }

}
