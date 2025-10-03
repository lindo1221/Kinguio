using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Player player;
    void Start()
    {
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
