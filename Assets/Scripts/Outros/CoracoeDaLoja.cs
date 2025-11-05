using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoracoeDaLoja : MonoBehaviour
{
    public int vidaMaxima;
    public Image[] coracao;
    public HeartSystem heart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VidaMaxAtual();
    }
    public void VidaMaxAtual() 
    {
      for (int i = 0; i < coracao.Length; i++) 
      {
        if(i < heart.vidaMaxima) 
        {
            coracao[i].enabled = true;
        }
        else 
        {
            coracao[i].enabled = false;
        }
        
      }
    }
}
