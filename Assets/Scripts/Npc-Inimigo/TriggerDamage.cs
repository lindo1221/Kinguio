using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    public Player player;
    public bool mortal = true;
    public bool knockbavel = true;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (mortal) 
        {
            if (collision.gameObject.CompareTag("player"))
            {
                heart.vida--;
                StartCoroutine(imortal());
            }
        }
       
    }
    public IEnumerator imortal()
    {
        mortal = false;
        yield return new WaitForSeconds(1f);
        mortal = true;
        knockbavel = false;
        yield return new WaitForSeconds(0.5f);
        knockbavel = true;
    }
}
