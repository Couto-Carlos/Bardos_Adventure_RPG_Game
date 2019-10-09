using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
   public string sceneLoad;
   public string personagem;
    public Vector2 LocalPersonagem;

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
