using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respiracao : MonoBehaviour
{
    public int ar;
    public int arMaximo;

    public Image[] Ars;
    public Sprite cheioAr;
    public Sprite vazioAr;
    public HeartSystem heartSystem;
    public float temposem = 3f;
    public float tempoMortal = 3f;
    public bool semAr = false;
    public GameObject painel;
    public Player player;


    public GameObject painelAr;

    private void Start()
    {
        painelAr.SetActive(false);
    }

    void Update()
    {
        Ar();
        Sufocar();
        temporizador();
      
    }

    public void Ar()
    {
        for (int i = 0; i < Ars.Length; i++)
        {
            if (i < ar)
            {                           
              Ars[i].sprite = cheioAr;                       
            }
            else
            {
                Ars[i].sprite = vazioAr;
            }
            if (i < arMaximo)
            {
                Ars[i].enabled = true;
            }
            else
            {
                Ars[i].enabled = false;
            }

        }
    }
    public void temporizador() 
    {
        if (semAr) 
        {
            temposem -= Time.deltaTime;            
        }
        if(ar <= 0) 
        {
          tempoMortal -= Time.deltaTime;
        }    
    }
   
    public void Sufocar()
    {
        if (temposem <= 0) 
        {
            ar--;
            temposem = 3;
        }
        if (ar <= 0 && tempoMortal <= 0)
        {
            heartSystem.vida--;
            heartSystem.piscar = true;
            tempoMortal = 3;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("agua"))
        {
            painel.SetActive(true);
            player.rg.drag = 0.4f;
            semAr = true;
            player.naAgua = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("agua"))
        {
            ar = arMaximo;
            painel.SetActive(false);
            semAr = false;
            player.naAgua = false;
            tempoMortal = 3f;
            temposem = 3f;
            heartSystem.piscar = false;
        }
    }
}
