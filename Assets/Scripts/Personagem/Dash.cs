using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
   public Player player;
    public float direcao;
    public bool estaemcool = false;
    public TrailRenderer tr;

    public bool temOColar = false;

    public Color color;
    void Start()
    {
       estaemcool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (temOColar)
        {
            direcao = player.transform.localScale.x;
            player.StartCoroutine(player.Desativar());

            if (estaemcool == false && context.phase == InputActionPhase.Performed)
            {
                StartCoroutine(Cooldown());
                if (context.phase == InputActionPhase.Performed && direcao >= 1)
                {
                    player.rg.AddForce(Vector2.right * 23, ForceMode2D.Impulse);
                }
                else if (context.phase == InputActionPhase.Performed)
                {
                    player.rg.AddForce(Vector2.left * 23, ForceMode2D.Impulse);
                }
                StartCoroutine(Animacao());
            }
        }

    }
    public IEnumerator Animacao() 
    {     
        tr.emitting = true;
        yield return new WaitForSeconds(0.2f);
        tr.emitting = false;
    }
    public IEnumerator Cooldown() 
    {
        estaemcool = true;
        yield return new WaitForSeconds(0.4f);
        estaemcool = false;
    }
}
