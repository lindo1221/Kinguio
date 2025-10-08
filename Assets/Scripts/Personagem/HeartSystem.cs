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

    void Update()
    {
        HealthLogic();
        DeadState();
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
    public void DeadState()
    {
        if (vida <= 0)
        {
            GetComponent<Player>().enabled = false; // verificar esse PlayerLogic
            Destroy(gameObject, 3.0f); //colocar esse método dentro do update

        }
    }
}
