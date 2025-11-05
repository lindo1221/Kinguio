using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Botaoes : MonoBehaviour
{
    public DialogueSystemnew dialogue;
    public GameObject abrirBarraca;
    public GameObject simOunao;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void OnSim() 
    {      
      abrirBarraca.SetActive(true);
        simOunao.SetActive(false);
    }
    public void OnNao()
    {
        dialogue.EndDialogue();
        Debug.Log("swxo");
    }
    public void OnSair() 
    {
      abrirBarraca.SetActive(false);
        OnNao();
    }
}
