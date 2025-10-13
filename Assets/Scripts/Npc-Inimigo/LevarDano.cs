using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevarDano : MonoBehaviour
{
    public Inimigo mover;
    public int vida = 10;
    public Energia energia;
    public bool receberEenrgia = true;
    public Inimigo inimigo;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque")) 
        {
            vida--;
            Knockback(collision , 2000);
        }
       
        if (collision.gameObject.CompareTag("power"))
        {
            vida -= 5;
            Knockback(collision, 2000);
            StartCoroutine(imortal());
            if (vida <= 0) 
            {
              receberEenrgia = false;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Knockback(collision.collider, 1200);
        }
    }
    public void Knockback(Collider2D collision, float forca) 
    {       
            Transform iniT = collision.transform;
            if (mover.rg.transform.position.x < iniT.position.x)
            {
                mover.rg.velocity = Vector3.zero;
                mover.rg.AddForce(Vector2.left.normalized * forca, ForceMode2D.Force);
            }
            else
            {
               mover.rg.velocity = Vector3.zero;
               mover.rg.AddForce(Vector2.right.normalized * forca);
            }        
    }
    public void Destroy()
    {
        if(vida <= 0 && receberEenrgia) 
        {
          energia.energiaPower += 10;
          Destroy(gameObject);
          receberEenrgia=true;
        }
        else if (vida <= 0 && !receberEenrgia) 
        {
          Destroy(gameObject);
        }
    }
    public IEnumerator imortal() 
    {   Vector2 ori = new Vector2(inimigo.bCollider.size.x, inimigo.bCollider.size.y);
        inimigo.bCollider.size = new Vector2(0, 0);
        yield return new WaitForSeconds(0.2f);
        inimigo.bCollider.size = ori;
    }
}
