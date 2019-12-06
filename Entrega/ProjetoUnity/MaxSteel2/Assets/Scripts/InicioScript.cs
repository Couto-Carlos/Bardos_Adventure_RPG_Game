using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioScript : MonoBehaviour
{
    public bool Sceneinicio = false;
    public bool Sceneinicio2 = false;
    public bool Sceneinicio5 = false;
    public bool Sceneinicio3 = false;
    public bool Sceneinicio4 = false;
    public bool Sceneinicio6 = false;
    public bool SceneInicio0 = false;
    public bool SceneInicioHelpFlute = false;
    public bool SceneInicioHelpMath = false;
    public bool Final = false;
    public GameObject FandIN;
    public GameObject FandOUT;
    public bool Load = false;
   
    // Start is called before the first frame update
    void Start()
    {
        if (FandOUT != null)
        {
            GameObject Panel = Instantiate(FandOUT, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(Panel, 1);
        }
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
                StartCoroutine(StartSceneWithFanding("Inicio2"));
            }
            else if (Sceneinicio2 == true)
            {
                StartCoroutine(StartSceneWithFanding("InicioHelpFlute"));
            }
            else if (Sceneinicio3 == true)
            {
                StartCoroutine(StartSceneWithFanding("Inicio4"));
            }
            else if (Sceneinicio4 == true)
            {
                StartCoroutine(StartSceneWithFanding("Load"));
            }
            else if (Sceneinicio5 == true)
            {
                StartCoroutine(StartSceneWithFanding("Inicio6"));
            }
            else if (Sceneinicio6 == true)
            {
                StartCoroutine(StartSceneWithFanding("Load"));
            }else if (SceneInicioHelpFlute)
            {
                StartCoroutine(StartSceneWithFanding("InicioHelpMath"));
            }else if (SceneInicioHelpMath)
            {
                StartCoroutine(StartSceneWithFanding("Inicio3"));
            }
            
            else if (Sceneinicio == true)
            {
                StartCoroutine(StartSceneWithFanding("Inicio"));
            }else if(Final == true)
            {
               // StartCoroutine(StartSceneWithFanding("FirstScene"));
            }
        }
        
        
        IEnumerator StartSceneWithFanding(string Scene)
        {
            Instantiate(FandIN, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
        }
        IEnumerator DELAY()
        {
            
         
            yield return new WaitForSeconds(2f);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mundo");
        }
    }
}
