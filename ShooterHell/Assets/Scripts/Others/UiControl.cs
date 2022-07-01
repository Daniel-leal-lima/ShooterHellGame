using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
    public float inimigosQuantidade = 0;
    public float foneQuantidade = 0;
    public Text textC, textF;

    private void Start() {}

    private void Update() 
    {
        textC.GetComponent<TextManager>().textValue = inimigosQuantidade;
        textF.GetComponent<TextManager>().textFone = foneQuantidade;
    }
}
