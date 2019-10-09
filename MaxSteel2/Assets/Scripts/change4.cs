using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change4 : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneLoad;
   public string personagem;
  // public Collider2D other;

  // private SceneManagement sceneManagement = new sceneManagement();
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AA VVASKDJsa");
        Debug.Log(other.CompareTag(personagem));
        if(other.CompareTag(personagem) && !other.isTrigger)
        {
            Debug.Log("ENTROU");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneLoad);
        }
    }
}
