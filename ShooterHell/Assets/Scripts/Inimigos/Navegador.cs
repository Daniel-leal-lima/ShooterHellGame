using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navegador : MonoBehaviour
{
    public GameObject point, player, area, inimigo, uiControl;
    public NavMeshAgent perseguidor;
    public bool atacar, chegou;
    public Animator animador;
    public Rigidbody2D rb;

    void Start()
    {
        uiControl = GameObject.Find("UiControl");
        perseguidor = GetComponent<NavMeshAgent>();
        perseguidor.updateRotation = false;
        perseguidor.updateUpAxis = false;
        point = GameObject.Find("Centro");
        player = GameObject.Find("Player");
        area = GameObject.Find("AreaPersegue");
    }

    // Update is called once per frame
    void Update()
    {
        if (chegou == true)
        {
            perseguidor.SetDestination(point.transform.position);
            animador.SetFloat("LookX", point.transform.position.x);
            animador.SetFloat("LookY", point.transform.position.y);
        }
        if (atacar == false)
        {
            perseguidor.SetDestination(point.transform.position);
            animador.SetFloat("LookX", point.transform.position.x);
            animador.SetFloat("LookY", point.transform.position.y);
        }
        else
        {
            perseguidor.SetDestination(player.transform.position);
            animador.SetFloat("LookX", player.transform.position.x - rb.position.x);
            animador.SetFloat("LookY", player.transform.position.y - rb.position.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Chegou"))
        {
            print("ok");
            inimigo.GetComponent<InimigoController>().vida = 0;
            uiControl.GetComponent<UiControl>().inimigosQuantidade += 1;
            chegou = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("AreaPlayer"))
        {
            atacar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("AreaPlayer"))
        {
            atacar = false;
        }
    }
}
