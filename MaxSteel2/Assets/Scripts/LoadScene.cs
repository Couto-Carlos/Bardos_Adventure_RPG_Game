using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string sceneLoad;
    public string personagem;
    public Vector2 LocalPersonagem;
    public Vector2 StartingPosition;
    public GameObject FandIN;
    public GameObject FandOUT;
    public Animator Fanding;
    public bool Ceifador;
    public bool Florista;
    public bool Lenhador;
    public bool OUT;
    public bool IN;
    GameObject Bardo;
    GameObject Mundo;
    public bool newPos;
    // public Collider2D other;

    // private SceneManagement sceneManagement = new sceneManagement();

    private void Awake()
    {
       Mundo = GameObject.FindGameObjectWithTag("Mundo");
        Bardo = GameObject.FindGameObjectWithTag("Link").gameObject;
        Debug.Log(Mundo);
        
    }
    private void Start()
    {
        if (FandOUT != null)
        {
            GameObject Panel = Instantiate(FandOUT, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(Panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        ///////////////////////////////////////////////////////////////////////
        // Fanding = GameObject.FindGameObjectWithTag("Fanding").gameObject.GetComponent<Animator>();    
        //Bardo.GetComponent<Movement>().StartPosit = true;
        //Bardo.GetComponent<Movement>().StartingPosition = BackPosition;
        Debug.Log("AA VVASKDJsa");
        Debug.Log(other.CompareTag(personagem));
        ////////////////////////////////////////////////////////////////////////

        if (other.CompareTag(personagem) && !other.isTrigger)
        {
           
            
            if (Florista == true)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Casa = true;
            }
            else if (Ceifador == true)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Casa = true;
            }
            else if (Lenhador == true)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Casa = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Casa = false;
            }
            ///////////////////////////////////////////////////////////////////
            Debug.Log("ENTROU");
            // Bardo.GetComponent<Movement>().BackPosition = BackPosition;
            // Bardo.GetComponent<Movement>().StartingPosition = Bardo.transform.position;
            //  StartCoroutine(Wait(1f));
            StartCoroutine(FandingCo(0.8f));
            ///////////////////////////////////////////////////////////////////
        }
    }
    IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
    }

    IEnumerator FandingCo(float f)
    {
        Mundo.GetComponent<StartingPosition>().Position = StartingPosition;
        if (newPos)
        {
            SceneManage.instance.lastPosition = new Vector2(Bardo.transform.position.x, Bardo.transform.position.y - 1);
            SceneManage.instance.taEntrando = true;
        } else
        {
            SceneManage.instance.taEntrando = false;
        }


        Instantiate(FandIN, Vector3.zero, Quaternion.identity);   
        yield return new WaitForSeconds(f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneLoad);
        Bardo.GetComponent<Movement>().StartPosit = true;
        
    }
}
