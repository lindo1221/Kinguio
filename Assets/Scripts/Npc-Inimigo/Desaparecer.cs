using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    public GameObject Poder;
    void Start()
    {
        StartCoroutine(Recarregar());
    }
    void Update()
    {
        
    }
    public IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(1f);
        Destroy(Poder);
    }

}
