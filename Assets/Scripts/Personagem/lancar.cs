using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lancar : MonoBehaviour
{
    public bool pegado = true;
    public GameObject prefabObe;
  
    public Rigidbody2D rbitem;
    public int forca = 900;
    public Transform posicaoDeLanca;
    public Transform tPlayer;

    void Start()
    {
        prefabObe.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void lancar(InputAction.CallbackContext context)
    {
        pegarposi();
        rbitem.velocity = Vector3.zero;
        if (tPlayer.localScale.x == 1 && pegado)
        {
          
            GameObject novoObjeto = Instantiate(prefabObe, posicaoDeLanca.position, Quaternion.identity);
            Rigidbody2D rbNovo = novoObjeto.GetComponent<Rigidbody2D>();
            rbNovo.AddForce(Vector2.right * forca);
            pegado = false;
            StartCoroutine(Recarregar());
        }

        if (tPlayer.localScale.x == -1 && pegado)
        {
            GameObject novoObjeto = Instantiate(prefabObe, posicaoDeLanca.position, Quaternion.identity);
            Rigidbody2D rbNovo = novoObjeto.GetComponent<Rigidbody2D>();
            rbNovo.AddForce(Vector2.left * forca);
            pegado = false;
            StartCoroutine(Recarregar());
        }
       
        // Se quiser permitir lançar de novo depois de um tempo:
    
    }
    public IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(0.5f); // tempo de "recarregar"
        pegado = true;
    }
    public void pegarposi()
    {    
        rbitem.transform.position = posicaoDeLanca.transform.position;
    }
}

