using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Escada : MonoBehaviour
{
    public BoxCollider2D subir;
    public BoxCollider2D descer;
    public bool teclapressionada = false;
    public Transform player; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {  
            
       if (collision.gameObject.CompareTag("player"))
       {
          player = collision.transform;
       }         
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.transform == player)
        {
            player = null;
        }
    }
    public void OnEscada(InputAction.CallbackContext context) 
    {
       
        if (context.phase == InputActionPhase.Performed && player != null)
            StartCoroutine(escada());
    }
    public IEnumerator escada() 
    {
        teclapressionada = true;
        Collider2D playerCollider = player.GetComponent<Collider2D>();

        if (playerCollider.IsTouching(subir))
        {
            player.position = descer.transform.position;
        }
        else if (playerCollider.IsTouching(descer))
        {
            player.position = subir.transform.position;
        }

        yield return new WaitForSeconds(0.2f);
        teclapressionada = false;
    }
}
