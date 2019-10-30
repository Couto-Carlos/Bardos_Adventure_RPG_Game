using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioScript : MonoBehaviour
{
   public bool Sceneinicio2 = false;
   public bool Sceneinicio5 = false;
   public bool Sceneinicio3 = false;
   public bool Sceneinicio4 = false;
   public bool Sceneinicio6 = false;
   public bool SceneInicio0 = false;
    public bool Load = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Load == true)
        {
            StartCoroutine(DELAY());
           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneInicio0 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio2");
            }
            else if (Sceneinicio2 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio3");
            }
            else if (Sceneinicio3 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio4");
            }
            else if (Sceneinicio4 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
            }
            else if (Sceneinicio5 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio6");
            }
            else if (Sceneinicio6 == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
            }
            
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio");
            }
        }
         
        IEnumerator DELAY()
        {
            yield return new WaitForSeconds(2f);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mundo");
        }
    }
}
