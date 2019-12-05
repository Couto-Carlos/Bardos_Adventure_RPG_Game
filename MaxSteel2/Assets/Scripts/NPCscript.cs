using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCscript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool bateu = false;
    public GameObject CanvasE;
    public GameObject CanvasText;
    void Start()
    {
        CanvasE = gameObject.transform.Find("Listener").transform.Find("CanvasE").gameObject;
        CanvasText = gameObject.transform.Find("Listener").transform.Find("CanvasText").gameObject;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Link") && !other.isTrigger)
        {
          
            bateu = true;
            CanvasE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CanvasE.SetActive(false);
        CanvasText.SetActive(false);
        bateu = false;
        resetText();
    }

    public void Update()
    {
        CanvasText.transform.Find("Text").GetComponent<charge_text>().parent = CanvasText;
            if (bateu)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CanvasE.SetActive(false);
                    CanvasText.SetActive(true);
                }
            }
    }
        void resetText()
    {
        try
        {
            CanvasE.GetComponentInChildren<charge_text>().E = gameObject.transform.Find("CanvasE").gameObject;
        } catch (Exception) { }
        CanvasText.GetComponentInChildren<charge_text>().resetText();
        CanvasText.GetComponentInChildren<Text>().text = "";
    }
}