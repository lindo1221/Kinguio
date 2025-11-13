using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    public bool foiataquedown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            player.StartCoroutine(player.Desativar());
            Knock2(collision.transform);
        }
    }
    public void Knock2(Transform collision) 
    {
        Transform iniT = collision.transform;
         
        if (rb.transform.position.x < iniT.position.x)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up.normalized * 200);
            rb.AddForce(Vector2.left.normalized * 400);
            Debug.Log("fsef");
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up.normalized * 200);
            rb.AddForce(Vector2.right.normalized * 400);
            Debug.Log("fs34534ef");
        }
      
    }


}
