using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayClose : MonoBehaviour
{
    // Start is called before the first frame update
    public string personagem;
    public Vector2 LocalPersonagem;
    private GameObject character;
    private bool bateu = false;
    public bool Rei;
    public bool filha;
    public bool Quarda;
    public bool Ceifador;
    public bool Florista;
    public bool Lenhador;
    public bool placa;

    // public Collider2D other;

    // private SceneManagement sceneManagement = new sceneManagement();
    public void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("bateu no trigger");
        if (Florista == true)
        {
            GameObject canvasFlorista = character.transform.Find("CanvasFlorista").gameObject;
            GameObject selectE = GameObject.FindGameObjectWithTag("CanvasCharacterFlorista").transform.Find("CanvasFlorista").gameObject;
            selectE = canvasFlorista;
            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca1 = true;
                bateu = true;
                canvasFlorista.SetActive(true);
            }
        }else if(placa == true)
        {
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            GameObject selectE = GameObject.Find("ListenerPlaca1").transform.Find("CanvasE").gameObject;
            selectE = canvasE;
            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                bateu = true;
                canvasE.SetActive(true);
            }
        }
        else if (Quarda == true)
        {
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            GameObject selectE = GameObject.FindGameObjectWithTag("Quarda").transform.Find("CanvasE").gameObject;
            selectE = canvasE;
            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca1 = true;
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca2 = true;
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca3 = true;
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Rei = true;
                bateu = true;
                canvasE.SetActive(true);
            }
        }
        else if (Rei == true)
        {
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            GameObject selectE = GameObject.FindGameObjectWithTag("Rei").transform.Find("CanvasE").gameObject;
            selectE = canvasE;
            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                bateu = true;
                canvasE.SetActive(true);
            }
        }
        else if (filha == true)
        {
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            GameObject selectE = GameObject.FindGameObjectWithTag("Filha").transform.Find("CanvasE").gameObject;
            selectE = canvasE;
            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                bateu = true;
                canvasE.SetActive(true);
            }
        }
        else
        {

            //Destrancar as portas para musica
            if (Ceifador)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca2 = true;
            }else if (Lenhador)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca3 = true;
            }else if (Quarda)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca1 = true;
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca2 = true;
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Tranca3 = true;
            }
            //

            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            GameObject selectE;


            if (Quarda)
            {
                selectE = GameObject.FindGameObjectWithTag("Quarda").transform.Find("CanvasE").gameObject;
                selectE = canvasE;
            }
            else if(filha){
                selectE = GameObject.FindGameObjectWithTag("Filha").transform.Find("CanvasE").gameObject;
                selectE = canvasE;
            }
            else if(Rei){
                selectE = GameObject.FindGameObjectWithTag("Rei").transform.Find("CanvasE").gameObject;
                selectE = canvasE;
            }
            else { 
            selectE = GameObject.FindGameObjectWithTag("CanvasCharacter").transform.Find("CanvasE").gameObject;
            selectE = canvasE;
            }

            if (other.CompareTag(personagem) && !other.isTrigger)
            {
                bateu = true;
                canvasE.SetActive(true);
            }
        }
    }
   private void OnTriggerExit2D(Collider2D other)
    {
        if (Florista == true)
        {
            Debug.Log("Saiu do Trigger");
            GameObject canvasTextFlorista = character.transform.Find("CanvasTextFlorista").gameObject;
            GameObject canvasFlorista = character.transform.Find("CanvasFlorista").gameObject;
            bateu = false;
            canvasTextFlorista.SetActive(false);
            canvasFlorista.SetActive(false);
            resetText();
        }
        else
        {
            Debug.Log("Saiu do Trigger");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
            bateu = false;
            canvasText.SetActive(false);
            canvasE.SetActive(false);
            resetText();
        }
    }
    void resetText()
    {
        if (Florista)
        {
            GameObject canvasE = character.transform.Find("CanvasTextFlorista").gameObject;
            canvasE.GetComponentInChildren<charge_text>().E = character.transform.Find("CanvasFlorista").gameObject;
            GameObject canvasText = character.transform.Find("CanvasTextFlorista").gameObject;
            canvasText.GetComponentInChildren<charge_text>().resetText();
            canvasText.GetComponentInChildren<Text>().text = "";
        }
        else if (placa)
        {
            GameObject canvasE = character.transform.Find("CanvasText").gameObject;
            canvasE.GetComponentInChildren<charge_text>().E = character.transform.Find("CanvasE").gameObject;
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.GetComponentInChildren<charge_text>().resetText();
            canvasText.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            GameObject canvasE = character.transform.Find("CanvasText").gameObject;
            canvasE.GetComponentInChildren<charge_text>().E = character.transform.Find("CanvasE").gameObject;
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.GetComponentInChildren<charge_text>().resetText();
            canvasText.GetComponentInChildren<Text>().text = "";
        }
    }

    public void Update()
    {
        if (Florista == true)
        {
            character = GameObject.FindGameObjectWithTag("CanvasCharacterFlorista");
            GameObject canvasText = character.transform.Find("CanvasTextFlorista").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasFlorista").gameObject;
            
            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        else if (placa)
        {
            character = GameObject.Find("ListenerPlaca1");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;

            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        else if (Quarda)
        {
            character = GameObject.FindGameObjectWithTag("Quarda");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;

            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Rei = true;
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        else if (filha)
        {
            character = GameObject.FindGameObjectWithTag("Filha");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;

            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        else if (Rei)
        {
            character = GameObject.FindGameObjectWithTag("Rei");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;

            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        else
        {
            character = GameObject.FindGameObjectWithTag("CanvasCharacter");
            GameObject canvasText = character.transform.Find("CanvasText").gameObject;
            canvasText.transform.Find("Text").GetComponent<charge_text>().parent = canvasText;
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;

            if (bateu)
            {
                //canvas2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvasE.SetActive(false);
                    canvasText.SetActive(true);
                }
            }
        }
        
    }
}
