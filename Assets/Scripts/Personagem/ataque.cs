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
    public Knock knock;
    public bool teste;

    public IEnumerator Configs()
    {
        if (atacou)
        {
            yield return new WaitForSeconds(0.05f);
            ataques.size = new Vector2(0, 1);
            atacou = false;
        }
        if (estaemcool)
        {
            yield return new WaitForSeconds(0.25f);
            estaemcool = false;
        }
    }
    public void OnAtacar(InputAction.CallbackContext context)
    {
        var Down = Keyboard.current.downArrowKey.isPressed;
        var up = Keyboard.current.upArrowKey.isPressed;
        if (context.phase == InputActionPhase.Performed && estaemcool == false && up)
        {
            ataque(1f, 3f);
            ataques.offset = new Vector2(-0.2f, 1);
        }
        else if (context.phase == InputActionPhase.Performed && estaemcool == false && Down)
        {
            ataque(1f, 3f);
            ataques.offset = new Vector2(-0.2f, -1f);
        }
        else if (context.phase == InputActionPhase.Performed && estaemcool == false)
        {
            ataque(3f, 1f);
            ataques.offset = new Vector2(0.6f, 0);
        }
    
    }
    void Start()
    {
        StartCoroutine(Configs());
        ataques.size = new Vector2(0, 1);
        boxAtaque.SetActive(true);
    }  
    void Update()
    {      
    }
    
    public void ataque(float x, float y) 
    {
        ataques.size = new Vector2(x, y);
        atacou = true;
        estaemcool = true;
        StartCoroutine(Configs());
    }
}
