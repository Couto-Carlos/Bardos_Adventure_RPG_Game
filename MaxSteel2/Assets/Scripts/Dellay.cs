using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dellay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Example(AudioSource audioSource, float time)
    {
        Debug.Log("COMECO");
        yield return new WaitForSeconds(time);
        audioSource.Play();
        Debug.Log("FIM");
    }
    IEnumerator ExampleLimp(float time)
    {
        Debug.Log("COMECO");
        yield return new WaitForSeconds(time);
        //limpar
        for (int i = 0; i < 6; i++)
        {
            string n = (i + 1).ToString();
            Image d = GameObject.FindGameObjectWithTag("A(" + n + ")").GetComponent<Image>();
            d.enabled = false;
        }
        for (int i = 0; i < 6; i++)
        {
            string n = (i + 1).ToString();
            Image d = GameObject.FindGameObjectWithTag("^(" + n + ")").GetComponent<Image>();
            d.enabled = false;
        }
        for (int i = 0; i < 6; i++)
        {
            string n = (i + 1).ToString();
            Image d = GameObject.FindGameObjectWithTag(">(" + n + ")").GetComponent<Image>();
            d.enabled = false;
        }
        for (int i = 0; i < 6; i++)
        {
            string n = (i + 1).ToString();
            Image d = GameObject.FindGameObjectWithTag("<(" + n + ")").GetComponent<Image>();
            d.enabled = false;
        }
        for (int i = 0; i < 6; i++)
        {
            string n = (i + 1).ToString();
            Image d = GameObject.FindGameObjectWithTag("v(" + n + ")").GetComponent<Image>();
            d.enabled = false;
        }
        Debug.Log("FIM");
    }
}
