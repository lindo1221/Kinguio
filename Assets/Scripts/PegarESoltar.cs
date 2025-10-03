using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PegarESoltar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabObe; // arraste aqui o objeto com a tag "obe"
    public Player player;
    public bool teste;
    void Update()
    {
        teste = player.pegado;
    }



    public void OnColocar(InputAction.CallbackContext context)
    { 
            if (context.phase == InputActionPhase.Performed && player.pegado)
            {
                Vector3 posicaoPlayer = transform.position;

                // Nova posição com -1 no eixo X
                Vector3 novaPosicao = new Vector3(posicaoPlayer.x - 1.5f, posicaoPlayer.y, posicaoPlayer.z);

                // Cria o objeto na nova posição
                Instantiate(prefabObe, novaPosicao, Quaternion.identity);

                player.pegado = false;
            }
    
    }

}
