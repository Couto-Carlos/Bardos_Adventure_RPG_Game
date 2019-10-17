using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float velocidade = 6;
    public Rigidbody2D corpo;
    public Animator animador;
    public AudioSource HurricaneSound;
    public AudioSource Ocarina_D;
    public AudioSource Ocarina_D2;
    public AudioSource Ocarina_F;
    public AudioSource Ocarina_B;
    public AudioSource Ocarina_A;
    public AudioSource MusicaDeFundo;
    public AudioSource MarioMusic;
    public AudioSource SongOfHealingMusic;
    public AudioSource SongOfTime;
    public AudioSource SongOfStorm;
    public AudioSource WIN;
    public GameObject Sounds;
    public bool Scene2 = false;
    public bool Scene3 = false;
    private AudioSource MusicaTocando;
    public bool OcarinaMode = false;
    Image Ocarinabase;
    Image A, D, E, C, B;
    

    bool tocando = false;
    int[] Notas = new int[6];
    int QNTNotas = 0;

    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        Sounds = GameObject.FindGameObjectWithTag("Sound");
        Ocarinabase = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        A = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        D = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        C = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        B = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        E = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
    }

    /*  IEnumerator Dellay(float time)
     {
         yield return new WaitForSeconds(time);     
     }*/

    void Update()
    {

        
        corpo.velocity = new Vector2(0, 0);

        if (OcarinaMode == false)
        {

            if (Input.GetKeyDown(KeyCode.G))
            {
                //Hurricane
                animador.SetTrigger("Atack");
                StartCoroutine(Example(HurricaneSound, .1f));

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Sounds.GetComponent<AudioSource>().mute = !Sounds.GetComponent<AudioSource>().mute;
                animador.SetTrigger("Ocarina");
                OcarinaMode = true;
                //Base Das Notas  
                Ocarinabase.enabled = true;

            }
            //else if em tudo else if (animator.SetInteger("Horizontal" == 0));
            if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1)
            {
                //EsquerdaCima
                corpo.velocity = new Vector2(-velocidade, velocidade);
                animador.SetInteger("Horizontal", -1);
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
            {
                //DireitaBaixo
                corpo.velocity = new Vector2(velocidade, -velocidade);
                animador.SetInteger("Horizontal", 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1)
            {
                //EsquerdaBaixo
                corpo.velocity = new Vector2(-velocidade, -velocidade);
                animador.SetInteger("Horizontal", -1);
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
            {
                //DireitaCima
                corpo.velocity = new Vector2(velocidade, velocidade);
                animador.SetInteger("Horizontal", 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                //Andar pra Direita
                corpo.velocity = new Vector2(velocidade, 0);
                animador.SetInteger("Horizontal", 1);

            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                //Andar pra Esquerda
                corpo.velocity = new Vector2(-velocidade, 0);
                animador.SetInteger("Horizontal", -1);
            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                //Andar pra Cima
                corpo.velocity = new Vector2(0, velocidade);
                animador.SetInteger("Vertical", 1);
            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                //Andar pra Baixo
                corpo.velocity = new Vector2(0, -velocidade);
                animador.SetInteger("Vertical", -1);
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                //parado
                animador.SetInteger("Horizontal", 0);
            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                //parado
                animador.SetInteger("Vertical", 0);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        else
        {
            //MUSICAS PARA OCARINA

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Sair do modo Ocarina
                animador.SetTrigger("OcarinaOVER");
                OcarinaMode = false;
                tocando = false;
                //Desativar OcarinaBase
                Ocarinabase.enabled = false;
                //PararMusicas
                MarioMusic.Stop();
                SongOfHealingMusic.Stop();
                //Volta Musica de fundo
                Sounds.GetComponent<AudioSource>().mute = !Sounds.GetComponent<AudioSource>().mute;
                //limpar
                QNTNotas = 0;
                Notas[0] = 0;
                Notas[1] = 0;
                Notas[2] = 0;
                Notas[3] = 0;
                Notas[4] = 0;
                Notas[5] = 0;

            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Ocarina_D.Play();
                // Localizar Onde colocar a Nota  
                if (QNTNotas == 0){
                    A = GameObject.FindGameObjectWithTag("A(1)").GetComponent<Image>();
                }else if (QNTNotas == 1){
                    A = GameObject.FindGameObjectWithTag("A(2)").GetComponent<Image>();
                }else if (QNTNotas == 2){
                    A = GameObject.FindGameObjectWithTag("A(3)").GetComponent<Image>();
                }else if (QNTNotas == 3){
                    A = GameObject.FindGameObjectWithTag("A(4)").GetComponent<Image>();
                }else if (QNTNotas == 4){
                    A = GameObject.FindGameObjectWithTag("A(5)").GetComponent<Image>();
                }else if (QNTNotas == 5){
                    A = GameObject.FindGameObjectWithTag("A(6)").GetComponent<Image>();
                }
                A.enabled = true;
                //
                //1
                //Notas[i] = "D";
                Notas[QNTNotas] = 1;
                QNTNotas++;

            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                //2
                Ocarina_D2.Play();
                // Localizar Onde colocar a Nota  
                if (QNTNotas == 0){
                    C = GameObject.FindGameObjectWithTag("^(1)").GetComponent<Image>();
                }else if (QNTNotas == 1){
                    C = GameObject.FindGameObjectWithTag("^(2)").GetComponent<Image>();
                }else if (QNTNotas == 2){
                    C = GameObject.FindGameObjectWithTag("^(3)").GetComponent<Image>();
                }else if (QNTNotas == 3){
                    C = GameObject.FindGameObjectWithTag("^(4)").GetComponent<Image>();
                }else if (QNTNotas == 4){
                    C = GameObject.FindGameObjectWithTag("^(5)").GetComponent<Image>();
                }else if (QNTNotas == 5){
                    C = GameObject.FindGameObjectWithTag("^(6)").GetComponent<Image>();
                }
                C.enabled = true;
                //
                //Notas[i] = "2";
                Notas[QNTNotas] = 2;
                QNTNotas++;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                //3
                Ocarina_A.Play();
                // Localizar Onde colocar a Nota  
                if (QNTNotas == 0){
                    D = GameObject.FindGameObjectWithTag(">(1)").GetComponent<Image>();
                }else if (QNTNotas == 1){
                    D = GameObject.FindGameObjectWithTag(">(2)").GetComponent<Image>();
                }else if (QNTNotas == 2){
                    D = GameObject.FindGameObjectWithTag(">(3)").GetComponent<Image>();
                }else if (QNTNotas == 3){
                    D = GameObject.FindGameObjectWithTag(">(4)").GetComponent<Image>();
                }else if (QNTNotas == 4){
                    D = GameObject.FindGameObjectWithTag(">(5)").GetComponent<Image>();
                }else if (QNTNotas == 5){
                    D= GameObject.FindGameObjectWithTag(">(6)").GetComponent<Image>();
                }
                D.enabled = true;
                //
                //Notas[i] = "A";
                Notas[QNTNotas] = 3;
                QNTNotas++;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                //4
                Ocarina_F.Play();
                // Localizar Onde colocar a Nota  
                if (QNTNotas == 0){
                    E = GameObject.FindGameObjectWithTag("v(1)").GetComponent<Image>();
                }else if (QNTNotas == 1){
                    E = GameObject.FindGameObjectWithTag("v(2)").GetComponent<Image>();
                }else if (QNTNotas == 2){
                    E = GameObject.FindGameObjectWithTag("v(3)").GetComponent<Image>();
                }else if (QNTNotas == 3){
                    E = GameObject.FindGameObjectWithTag("v(4)").GetComponent<Image>();
                }else if (QNTNotas == 4){
                    E = GameObject.FindGameObjectWithTag("v(5)").GetComponent<Image>();
                }else if (QNTNotas == 5){
                    E = GameObject.FindGameObjectWithTag("v(6)").GetComponent<Image>();
                }
                E.enabled = true;
                //
                //Notas[i] = "F";
                Notas[QNTNotas] = 4;
                QNTNotas++;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                //5
                Ocarina_B.Play();
                // Localizar Onde colocar a Nota  
                if (QNTNotas == 0){
                    B = GameObject.FindGameObjectWithTag("<(1)").GetComponent<Image>();
                }else if (QNTNotas == 1){
                    B = GameObject.FindGameObjectWithTag("<(2)").GetComponent<Image>();
                }else if (QNTNotas == 2){
                    B = GameObject.FindGameObjectWithTag("<(3)").GetComponent<Image>();
                }else if (QNTNotas == 3){
                    B = GameObject.FindGameObjectWithTag("<(4)").GetComponent<Image>();
                }else if (QNTNotas == 4){
                    B = GameObject.FindGameObjectWithTag("<(5)").GetComponent<Image>();
                }else if (QNTNotas == 5){
                    B = GameObject.FindGameObjectWithTag("v(6)").GetComponent<Image>();
                }
                B.enabled = true;
                //
                //Notas[i] = "B";
                Notas[QNTNotas] = 5;
                QNTNotas++;
            }
            Debug.Log("Sounds: " + Notas[0] + " " + Notas[1] + " " + Notas[2] + " " + Notas[3] + " " + Notas[4] + "" + Notas[5]);

            if (tocando == false)
            {

                if (Notas[0] == 5 && Notas[1] == 5 && Notas[2] == 5 && Notas[3] == 4 && Notas[4] == 5 && Notas[5] == 2)
                {
                    MarioMusic.Play();
                    tocando = true;
                    Debug.Log("Tocou");

                }
                else if (Notas[0] == 5 && Notas[1] == 3 && Notas[2] == 4 && Notas[3] == 5 && Notas[4] == 3 && Notas[5] == 4)
                {
                    if (Scene2 == true)
                    {
                        StartCoroutine(Example(WIN, 2.5f));
                        GameObject Parede = GameObject.FindGameObjectWithTag("Portao1");
                        //  Destroy(Parede);
                        Parede.SetActive(false);
                    }
                    SongOfHealingMusic.Play();
                    tocando = true;
                    Debug.Log("CARLOS EDUARDO");
                }
                else if (Notas[0] == 1 && Notas[1] == 4 && Notas[2] == 2 && Notas[3] == 1 && Notas[4] == 4 && Notas[5] == 2)
                {
                    float aux = 0.0f ;
                    if (Scene3 == true)
                    {
                        WIN.Play();
                        GameObject Parede = GameObject.FindGameObjectWithTag("Portao2");
                        //  Destroy(Parede);
                        Parede.SetActive(false);
                        aux = 0.2f;
                    }
                    StartCoroutine(Example(SongOfStorm, aux));
                    aux = 0.0f;
                    tocando = true;
                    Debug.Log("CARLOS EDUARDO");
                }
                else if (Notas[0] == 3 && Notas[1] == 1 && Notas[2] == 4 && Notas[3] == 3 && Notas[4] == 1 && Notas[5] == 4)
                {
                    SongOfTime.Play();
                    tocando = true;
                }
                    if (QNTNotas == 6)
                    {
                    if (tocando == false)
                    {
                        //limpar
                        StartCoroutine(ExampleLimp(0.0f));
                    }
                    else
                    {
                        StartCoroutine(ExampleLimp(4.0f));
                    }
                        Notas[0] = 0;
                        Notas[1] = 0;
                        Notas[2] = 0;
                        Notas[3] = 0;
                        Notas[4] = 0;
                        Notas[5] = 0;
                        QNTNotas = 0;
                    tocando = false;
                    
                    }
            }
            
        }
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
//////////////////////////////////////////////////////////////////////////////////
 /*
   public class WaitForSecondsExample : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        Debug.Log("COMECO");
        yield return new WaitForSeconds(5);
        
        Debug.Log("FIM");
    }
}
 */
 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

