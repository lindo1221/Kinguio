using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    public GameObject tranca;
    public bool temChave = false;
    public GameObject avisoTranca;
    public Player player;
    void Start()
    {
        if(tranca != null)
        avisoTranca.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            if (temChave)
            {
                tranca.SetActive(true);
                player.item.sprite = null;
            }
            else
            {
                avisoTranca.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision) 
        {
            avisoTranca.SetActive(false);
        }
    }
}
