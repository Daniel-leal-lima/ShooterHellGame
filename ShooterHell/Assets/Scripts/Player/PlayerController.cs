using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public enum ESTADO { COM_ABAF, SEM_ABAF }
    // Var de movimento
    private Rigidbody2D rb;
    private Vector2 movimento;
    [SerializeField] private int velocidade;
    //var aux
    public Camera cam;
    Vector2 mousePos;
    public GameObject abafador;
    //var de batalha
    public float vida;
    private float vidaMAX;
    private float danosTomados;
    public float tempoRuido;
    public float tempoRestante;
    public float volumeRuido = 0;
    private ESTADO estado = ESTADO.COM_ABAF;
    public Animator animador;
    public GameObject uiControl;


    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        vidaMAX = vida;
        danosTomados = 0;
        tempoRestante = tempoRuido;
        rb = GetComponent<Rigidbody2D>();
        uiControl = GameObject.Find("UiControl");
    }
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            //está morto
            //Debug.Log("Está Morto!");
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
        AudioManager.instance.SetVolume("ruido", volumeRuido);
        Timer();
    }
    private void FixedUpdate()
    {
        Movimentar();
    }
    void Timer()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            uiControl.GetComponent<UiControl>().foneQuantidade = tempoRestante;
            volumeRuido += 0.0001f;
        }
        else
        {
            PerdeAbafador();
            tempoRestante = 0;
        }
        //Debug.Log("Tempo Restante: " + tempoRestante);
    }
    void Movimentar()
    {
        movimento.x = Input.GetAxis("Horizontal");
        movimento.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
        //AudioManager.instance.Play("passo");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distMouse = mousePos - rb.position;
        float angulo = Mathf.Atan2(distMouse.y, distMouse.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angulo;
        animador.SetFloat("LookX", distMouse.x);
        animador.SetFloat("LookY", distMouse.y);
    }
    void TomaDano(float dano)
    {
        //Debug.Log("Player acaba de receber " + dano.ToString() + " de dano!");

        vida -= dano;

        if (danosTomados >= 3)
        {
            PerdeAbafador();
        }
        else { danosTomados += 1; }
    }
    void PerdeAbafador()
    {
        estado = ESTADO.SEM_ABAF;
        abafador.SetActive(false);
        volumeRuido = 1;
    }
    void RecebeAbafador()
    {
        estado = ESTADO.COM_ABAF;
        abafador.SetActive(true);
        tempoRestante = tempoRuido;
        danosTomados = 0;
        volumeRuido = 0;
    }
}