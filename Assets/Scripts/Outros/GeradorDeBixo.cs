using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeBixo : MonoBehaviour
{
    public GameObject[] inimigos;
    public GameObject posi;
    public bool soumakrlh = true;
   
    void Start()
    {
        gerar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gerar() 
    {       
          int chances = Random.Range(0, inimigos.Length);      
          if (inimigos.Length != null && soumakrlh) 
          {
                GameObject monstro = Instantiate(inimigos[chances]);
                monstro.SetActive(true);
                monstro.transform.position = posi.transform.position;
                soumakrlh = false;
          }    
    }
}
