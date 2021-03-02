using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public int resistencia;
    private AudioSource audio1;
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio1.Play();
        resistencia--;
        if (resistencia <= 0)
        {
            Destroy(gameObject, audio1.clip.length);
        } else if (resistencia == 1){
            GetComponent<SpriteRenderer>().material.color = Color.white;
        } else if (resistencia == 2){
            GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
        
    }
}
