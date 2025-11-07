using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Mapa : MonoBehaviour
{
    public bool possuiMapa = false;
    public GameObject mapa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAbrirMapa(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (possuiMapa) 
            {  
              if (mapa != null)
              {
                if (!mapa.active)
                {
                    mapa.SetActive(true);
                }
                else
                {
                    mapa.SetActive(false);
                }
              }
            }
       
        }
    }
}
