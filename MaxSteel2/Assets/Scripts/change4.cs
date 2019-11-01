using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change4 : MonoBehaviour
{
    public string sceneLoad;
   public string personagem;
    public void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.CompareTag(personagem) && !other.isTrigger)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneLoad);
        }
    }
}
