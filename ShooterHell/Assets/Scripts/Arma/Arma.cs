using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    public Transform pontoDeDisparo;
    public GameObject balaPrefab;
    float forcaTiro = 20f;


    public float fireRate = 10f; // Change this in the inspector to increase/decrease how fast you fire.
    private float timeToFire;
    private float timeToFireMax = 1f;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && timeToFire <= 0f)
        {
            Atirar();
            timeToFire = timeToFireMax;
            AudioManager.instance.Play("shoot");

        }
        else if (timeToFire > 0f)
        {
            timeToFire -= fireRate * Time.deltaTime;
        }
    }

    void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(pontoDeDisparo.up * forcaTiro, ForceMode2D.Impulse);

    }
}