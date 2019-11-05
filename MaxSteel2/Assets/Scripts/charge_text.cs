using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charge_text : MonoBehaviour
{
    // Start is called before the first frame update

    public float delay = 0.06f;
    public string[] texts;
    private string currentText = "";
    public bool TextVector;
    private bool TextoPassado;

    void OnEnable()
    {
        StartCoroutine(ShowText());
        mensagemAtual = 0;
    }

    int mensagemAtual = 0;

    public GameObject parent;
    public GameObject E;

    IEnumerator ShowText()
    {
        Debug.Log("MENSAGEM ATUAL:" + mensagemAtual);
        if (mensagemAtual == texts.Length)
        {
            mensagemAtual = 0;
            parent.SetActive(false);
            E.SetActive(true);
        }
        else { 
        string TextoCompleto = texts[mensagemAtual];
            delay = 0.06f;
                TextoPassado = false;
                for (int i = 0; i <= TextoCompleto.Length; i++)   {
                    if (TextoPassado){
                        this.GetComponent<Text>().text = TextoCompleto;
                        break;
                    }
                    currentText = TextoCompleto.Substring(0, i);
                    this.GetComponent<Text>().text = currentText;
                    yield return new WaitForSeconds(delay);
                    if(currentText == TextoCompleto)  {
                        TextoPassado = true;    
                    }
                }
        }
    }
    
    public void Update()
    {
        Debug.Log(TextoPassado);
        Debug.Log(delay);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TextoPassado == true) {
                mensagemAtual++;
                StartCoroutine(ShowText());
            }
            else
            {
                //float auxdelay = delay;
                TextoPassado = true;
                //StartCoroutine(Wait(1f));
                //delay = auxdelay;
            }
        }
    }

    IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
    }


        public void resetText()
    {
        mensagemAtual = 0;
        currentText = "";
        // FullText = "";
    }
}
