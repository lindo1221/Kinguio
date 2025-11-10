using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    public GameObject tranca;
    public bool temChave;
    public GameObject avisoTranca;
    void Start()
    {
        if(tranca != null)
        tranca.SetActive(false);
        avisoTranca.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            if (temChave)
            {
                tranca.SetActive(true);
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
