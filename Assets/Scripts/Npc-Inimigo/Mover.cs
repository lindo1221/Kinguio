using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rg;
    public float velocidade = 0;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rg.velocity = new Vector2(velocidade, rg.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("virar")) 
        {
            velocidade *= -1;
            rg.transform.localScale = new Vector2(-1 * rg.transform.localScale.x, rg.transform.localScale.y);
        }
    }
}
