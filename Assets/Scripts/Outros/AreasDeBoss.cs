using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreasDeBoss : MonoBehaviour
{
    public GameObject barraNome;
    public TextMeshProUGUI nome;
    public GameObject vida;
    public string NomeDoBoss;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            barraNome.SetActive(true);
            nome.text = NomeDoBoss;
            vida.SetActive(true);
        }        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            barraNome.SetActive(false);
            nome.text = NomeDoBoss;
            vida.SetActive(false);
        }
    }
}
