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
    private bool E = false;
    // public Collider2D other;

    // private SceneManagement sceneManagement = new sceneManagement();
    public void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("bateu no trigger");
        GameObject canvas2 = character.transform.Find("Canvas2").gameObject;
        if (other.CompareTag(personagem) && !other.isTrigger)
            {
            bateu = true;
            canvas2.SetActive(true);
        }
        
    }
   private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ksksksks");
        GameObject canvass = character.transform.Find("Canvass").gameObject;
        GameObject canvas2 = character.transform.Find("Canvas2").gameObject;
        bateu = false;
        canvass.SetActive(false);
        canvas2.SetActive(false);
    }

    public void Update()
    {
        character = GameObject.FindGameObjectWithTag("CanvasCharacter");
        GameObject canvass = character.transform.Find("Canvass").gameObject;
        GameObject canvas2 = character.transform.Find("Canvas2").gameObject;

        if (bateu)
        {
            //canvas2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas2.SetActive(false);
                canvass.SetActive(true);
            }
        }
        
    }
}
