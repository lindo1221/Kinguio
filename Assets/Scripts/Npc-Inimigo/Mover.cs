using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform pontoA; //Guarda a posição ponto A]
    public Transform pontoB; //Guarda a posição ponto B
    public Transform plataforma; //Guarda a posição da Plataforma
    public float velocidade = 1f; //Velocidade da Plataforma

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pontoA.position; //inicia a plataforma no ponto A
        plataforma = pontoB;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, plataforma.position, velocidade * Time.deltaTime); //move a plataforma

        if (Vector3.Distance(transform.position, plataforma.position) < 0.2f) //Verifica se a plataforma chegou no pontoA
        {
            if (plataforma == pontoB) //se a plataforma estiver indo para o ponto B
            {
                transform.localScale = new Vector2(transform.localScale.x *-1, transform.localScale.y);
                plataforma = pontoA; //muda a plataforma para o ponto A
            }
            else
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                plataforma = pontoB; //muda a plataforma para o ponto B
            }
            
        }
    }
}
