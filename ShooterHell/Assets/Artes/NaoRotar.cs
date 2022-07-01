using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoRotar : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D player;
    private Vector2 movimento;
    [SerializeField] private int velocidade;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movimentar();
    }

    void Movimentar()
    {
        rb.MovePosition(player.position);


    }
}
