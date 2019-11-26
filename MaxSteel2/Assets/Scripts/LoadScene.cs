using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string sceneLoad;
    public string personagem;
    public Vector2 StartingPosition;
    public GameObject FandIN;
    public GameObject FandOUT;
    public bool Ceifador;
    public bool Florista;
    public bool Lenhador;
    public bool Rei;
    public bool Final = false;
    GameObject Bardo;
    GameObject Mundo;
    public bool newPos;

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
        if (other.CompareTag(personagem) && !other.isTrigger)
        {
            if (Final)
            {
                Destroy(Bardo);
            }
            if (GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().Rei)
            {
                GameObject.FindGameObjectWithTag("Link").GetComponent<Movement>().TocandoProRei = 0;
            }
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
            StartCoroutine(FandingCo(0.8f));
            /////////////////////////////////////////////////////////////////
        }
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
