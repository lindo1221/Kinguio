using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    public TriggerDamage dano;
    public Rigidbody2D rb;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (dano.knockbavel)
        {
            if (collision.gameObject.CompareTag("inimigo"))
            {
                Transform iniT = collision.transform;
                if (rb.transform.position.x < iniT.position.x)
                {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector2.left.normalized * 5000, ForceMode2D.Force);
                }
                else
                {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector2.up.normalized * 300);
                    rb.AddForce(Vector2.right.normalized * 4000);
                }

            }
        }

    }


}
