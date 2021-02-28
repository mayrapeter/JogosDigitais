using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public int resistencia;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        resistencia--;
        if (resistencia <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
