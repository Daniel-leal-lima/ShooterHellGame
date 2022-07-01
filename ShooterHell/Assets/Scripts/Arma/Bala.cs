using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject hitEfeito;
    public float delayDestruirTiro = 5f;
    public float dano = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Inimigo"))
        {
            //GameObject efeito = Instantiate(hitEfeito, transform.position, Quaternion.identity);
            AudioManager.instance.Play("explosion");
            //Destroy(efeito, delayDestruirTiro);
            Destroy(gameObject);
            // Dano no Inimigo
            collision.gameObject.SendMessage("TomaDano", dano);
        }
        else if (collision.gameObject.tag != "Player"){
            //GameObject efeito = Instantiate(hitEfeito, transform.position, Quaternion.identity);
            AudioManager.instance.Play("explosion");
            //Destroy(efeito, delayDestruirTiro);
            Destroy(gameObject);
            
        }
        
    }
}
