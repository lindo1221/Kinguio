using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveInicial : MonoBehaviour
{
    public Player player;
    public SpriteRenderer sprite;
    public GameObject chave;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {       
            Destroy(gameObject);
            player.temAChave = true;
            player.balao.sprite = sprite.sprite;
        }
    }

}
