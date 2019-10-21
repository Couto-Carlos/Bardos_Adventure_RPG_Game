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

    // public Collider2D other;

    // private SceneManagement sceneManagement = new sceneManagement();
    public void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("bateu no trigger");
            GameObject canvasE = character.transform.Find("CanvasE").gameObject;
        if (other.CompareTag(personagem) && !other.isTrigger)
            {
            bateu = true;
            canvasE.SetActive(true);
        }
        
    }
   private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Saiu do Trigger");
        GameObject canvasText = character.transform.Find("CanvasText").gameObject;
        GameObject canvasE = character.transform.Find("CanvasE").gameObject;
        bateu = false;
        canvasText.SetActive(false);
        canvasE.SetActive(false);
        resetText();
    }

    void resetText()
    {
        GameObject canvasText = character.transform.Find("CanvasText").gameObject;
        canvasText.GetComponentInChildren<charge_text>().resetText();
        canvasText.GetComponentInChildren<Text>().text = "";
    }

    public void Update()
    {
        character = GameObject.FindGameObjectWithTag("CanvasCharacter");
        GameObject canvasText = character.transform.Find("CanvasText").gameObject;
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
