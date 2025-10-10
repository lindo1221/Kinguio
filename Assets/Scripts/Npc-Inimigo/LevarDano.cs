using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevarDano : MonoBehaviour
{
    public int vida = 10;
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
        }
    }

    public void Destroy()
    {
        if(vida <= 0) 
        {
         Destroy(gameObject);
        }
    }
}
