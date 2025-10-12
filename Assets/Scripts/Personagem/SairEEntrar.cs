using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SairEEntrar : MonoBehaviour
{
    public GameObject icone;
    public bool podeEntrar = false;
    void Start()
    {
        icone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEntrar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && podeEntrar)
        {
            SceneManager.LoadScene("Cabana");
            podeEntrar = false;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("entrar"))
        {
            icone.SetActive(true);
            podeEntrar = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("entrar"))
        {
            icone.SetActive(false);
            podeEntrar = false;
        }

    }
}
