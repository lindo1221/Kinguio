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

    public IEnumerator Neymar() 
    {
        if (atacou)
        {
            yield return new WaitForSeconds(0.05f);
            ataques.size = new Vector2(0, 1);
            atacou = false;
        }
        if (estaemcool) 
        {
            yield return new WaitForSeconds(0.3f);
            estaemcool = false;
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
            StartCoroutine(Neymar());
        }
    }
    void Start()
    {
        StartCoroutine(Neymar());
        ataques.size = new Vector2(0, 1);
        boxAtaque.SetActive(true);
    }  
    void Update()
    {      
    }
}
