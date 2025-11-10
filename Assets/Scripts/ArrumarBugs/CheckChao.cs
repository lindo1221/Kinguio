using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckChao : MonoBehaviour
{
    public Transform checkChao;
    public Player player;  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            player.Djump = true;
        }
    }
}
