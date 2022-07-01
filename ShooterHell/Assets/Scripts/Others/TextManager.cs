using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float textValue, textFone;
    public string textCarro, textFoneVida;
    public Text textC, textF;

    void Start()
    {
        textCarro = textValue.ToString();
        textC.text = textCarro + " %";

        textFoneVida = textFone.ToString("F2");
        textF.text = textFoneVida + " %";
    }

    void Update()
    {
        textCarro = textValue.ToString();
        textC.text = textCarro + " %";

        textFoneVida = textFone.ToString("F2");
        textF.text = textFoneVida + " %";
    }
}
