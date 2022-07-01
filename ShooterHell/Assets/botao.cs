using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao : MonoBehaviour
{


    bool venceu;

    public GameObject objeto;

    public Slider slider;

    float valor;

    public int slicerCont;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void troca()
    {
        AudioManager.instance.Play("ruido");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        
    }

    public void menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if (venceu)
        {
            Time.timeScale = 0;
            objeto.SetActive(true);
        }

        valor += Time.deltaTime;
        slider.value = valor;
    }

    public void Vencer()
    {
        venceu = true;
    }
}
