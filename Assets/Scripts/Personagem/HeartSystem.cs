using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    // Start is called before the first frame update
   public int vida;
   public int vidaMaxima;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    public bool piscar = false;
    public float tempoPiscaOff = 0.3f;
    public float tempoPiscaOn = 1;

    void Update()
    {
        HealthLogic();
        DeadState();
        piscaHearty();
    }

    public void HealthLogic()
    {
        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {                               
              coracao[i].sprite = cheio;                  
            }
            else
            {
                coracao[i].sprite = vazio;
            }
            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
          
        }
    }
    public void piscaHearty()
    {
        if (piscar)
        {
            tempoPiscaOn -= Time.deltaTime;
            tempoPiscaOff = 0.5f;
        }
        if (tempoPiscaOff < 0)
        {
            tempoPiscaOff -= Time.deltaTime;
            tempoPiscaOn = 0.3f;
        }

    }
    public void DeadState()
    {
        if (vida <= 0)
        {
            GetComponent<Player>().enabled = false; // verificar esse PlayerLogic
            Destroy(gameObject, 3.0f); //colocar esse método dentro do update

        }
    }
}
