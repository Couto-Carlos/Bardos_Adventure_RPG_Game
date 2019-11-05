using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
   public string sceneLoad;
   public string personagem;
    public Vector2 LocalPersonagem;
    public Vector2 BackPosition;
    public GameObject Fand;
    public Animator Fanding;
    public bool OUT;
    public bool IN;
    // public Collider2D other;

    // private SceneManagement sceneManagement = new sceneManagement();

    private void Awake()
    {
        if (Fand != null)
        {
           GameObject Panel = Instantiate(Fand, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(Panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        ///////////////////////////////////////////////////////////////////////
       // Fanding = GameObject.FindGameObjectWithTag("Fanding").gameObject.GetComponent<Animator>();
        GameObject Bardo = GameObject.FindGameObjectWithTag("Link").gameObject;
        Bardo.GetComponent<Movement>().TrocaDeTela = true;
        Debug.Log("AA VVASKDJsa");
        Debug.Log(other.CompareTag(personagem));
        ////////////////////////////////////////////////////////////////////////
        
        if (other.CompareTag(personagem) && !other.isTrigger)
        {           
            ///////////////////////////////////////////////////////////////////
            Debug.Log("ENTROU");
            Bardo.GetComponent<Movement>().BackPosition = BackPosition;
            Bardo.GetComponent<Movement>().StartingPosition = Bardo.transform.position;
            StartCoroutine(FandingCo(0.5f));
            ///////////////////////////////////////////////////////////////////
        }
    }
    IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
    }

    IEnumerator FandingCo(float f)
    {
        if (Fand != null)
        {
            Instantiate(Fand, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(f);
        AsyncOperation Assync = SceneManager.LoadSceneAsync(sceneLoad);
        while (!Assync.isDone)
        {
            yield return null;
        }
    }
}
