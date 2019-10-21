using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charge_text : MonoBehaviour
{
    // Start is called before the first frame update

    public float delay = 0.1f;
    public string FullText;
    private string currentText = "";
    void Start()
    {
        StartCoroutine(ShowText());
    }

    // Update is called once per frame
    IEnumerator ShowText()
    {
        for(int i = 0; i < FullText.Length; i++)
            {
            currentText = FullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

            }

    }
}
