using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
        public Transform player;
        public Vector3 posicaoPlayer;
        public Transform cenario;

    void Update()
    {
            posicaoPlayer = player.position;
            float px = posicaoPlayer.x;
            float py = posicaoPlayer.y;
            float pz = posicaoPlayer.z;
            cenario.position = new Vector3(px, cenario.position.y, 0);
    }

}

