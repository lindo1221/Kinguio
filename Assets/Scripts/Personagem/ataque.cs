using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class adesgracadoataque : MonoBehaviour
{
    public BoxCollider2D ataques;
    public float tim = 0.05f;
    public bool atacou = false;
    public GameObject boxAtaque;
    public float cooldown = 0.5f;
    public bool estaemcool = true;
    public Transform ataqueposi;
    public void ataqueTime()
    {
        if (atacou)
        {
            tim -= Time.deltaTime;
        }
        if (estaemcool)
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0)
        {
            estaemcool = false;
            cooldown = 0.5f;
        }
        if (tim <= 0)
        {
            ataques.size = new Vector2(0, 1);
            atacou = false;
            tim = 0.05f;
           
        }
    }
    public void pegarAposi() 
    {
       ataques.transform.position = ataqueposi.position;
    
    }
    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && estaemcool == false)
        {
            pegarAposi();
            ataques.size = new Vector2(2, 1);
            atacou = true;
            estaemcool = true;
        }
    }
    void Start()
    {
        ataques.size = new Vector2(0, 1);
        boxAtaque.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ataqueTime();
    }
}
