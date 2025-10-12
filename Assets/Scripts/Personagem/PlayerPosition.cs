using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
        public Transform player; // arraste o Player aqui no Inspector
        public Vector3 posicaoPlayer;
    void Update()
    {
            // Sempre pega a posição atual do player
            posicaoPlayer = player.position;

            // Se quiser acessar cada eixo:
            float px = posicaoPlayer.x;
            float py = posicaoPlayer.y;
            float pz = posicaoPlayer.z;

           
    }

}

