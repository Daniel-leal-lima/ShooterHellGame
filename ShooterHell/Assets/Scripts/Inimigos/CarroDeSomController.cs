using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroDeSomController : MonoBehaviour
{
    public float condicaoAtual;
    public float maxInterações;
    public float porcentagem;

    private void Update() {
        porcentagem = (condicaoAtual / maxInterações) * 100;
        //Debug.Log("Porcentagem:" + porcentagem);
    }

    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Inimigo")
        {
            condicaoAtual += 1f;
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            condicaoAtual += 1f;
        }
    }
}
