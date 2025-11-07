using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LojaBotoes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Button LojaBotoesButton;
	public bool emCima = false;
	public int valor;
	public TextMeshProUGUI texto;
	public Image coração;
	public GameObject vidaMinima;
	public HeartSystem heart;
	public bool jaFoiComprado = false;
	public string nomeDoItem;

    public Mapa mapa;
	public Dash dash;


    void Start()
	{
        ColorBlock cB = LojaBotoesButton.colors;
    }

	// Update is called once per frame
	void Update()
	{
		if (emCima)
		{
			texto.text = "-" + valor.ToString();
			coração.enabled = true;          
		}
		else 
		{
			texto.text = "Buy";        
			coração.enabled = false;
		}
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		emCima = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		emCima = true;
	}
	public void OnClick() 
	{
       
        if (jaFoiComprado == false)
		{
			if (heart.vidaMaxima - valor < 5)
			{
				StartCoroutine(sumirAviso());
			}
			else
			{
				heart.vidaMaxima -= valor; jaFoiComprado = true;
                if (nomeDoItem != null)
                {
                    switch (nomeDoItem)
                    {
                        case "Mapa":
                            mapa.possuiMapa = true; break;
                        case "Colar":
                            dash.temOColar = true; break;
                    }
                }
            }
        }
    }

	public IEnumerator sumirAviso() 
	{
        vidaMinima.SetActive(true);
		yield return new WaitForSeconds(3f);
        vidaMinima.SetActive(false);
    }
}
