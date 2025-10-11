using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaVisual : MonoBehaviour
{
    public Image tenta;
    public Transform Ele;
    public Energia energia;
    public float BarraTotal = 100;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        sla();
    }

    public void sla() 
    {
        float Atual = energia.energiaPower / BarraTotal;
        tenta.transform.localScale = new Vector3(Atual,tenta.transform.localScale.y, 0);
        
    }

    
}
