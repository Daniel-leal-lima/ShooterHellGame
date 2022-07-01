using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    //var principais
    public float vida;
    private int chanceDrop;
    public int chanceDropMAX;
    public GameObject abafador, piranha;

    //var batalha
    public float danoFisico = 5f;
    // Start is called before the first frame
    void Start()
    {
        chanceDrop = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            //está morto
            Morre();
        }
    }

    void TomaDano(float dano)
    {
        //Debug.Log("Inimigo: "+ this.gameObject.name+" Acaba de receber " + dano.ToString() + " de dano!");
        vida -= dano;
    }

    void Morre()
    {
        if (chanceDrop < chanceDropMAX)
        {
            //caso ele tenha probabilidade de spawnar
            Instantiate(abafador, transform.position, Quaternion.identity);
        }
        Debug.Log("chance de drop foi de: " + chanceDrop);
        Destroy(piranha);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("TomaDano", danoFisico);
        }
    }
}