using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
   
    public Rigidbody2D rg;
    public float velocidade = 0;
    public BoxCollider2D bCollider;
    public bool isGrounded = true;
    public bool primeirotoque = true;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isGrounded)
            rg.velocity = new Vector2(velocidade, rg.velocity.y);
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("virar")) 
    //    {
    //         velocidade *= -1;
    //         rg.transform.localScale = new Vector2(-1 * rg.transform.localScale.x, rg.transform.localScale.y);
    //         primeirotoque = false;        
    //    }
    //}
    public IEnumerator sla()
    {
        isGrounded = false;
        yield return new WaitForSeconds(0.3f);
        isGrounded = true;
    }


}
