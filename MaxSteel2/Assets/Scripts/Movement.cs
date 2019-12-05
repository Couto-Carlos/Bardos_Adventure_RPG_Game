using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;	
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System;

public class Movement : MonoBehaviour
{
   
   
    //RigidBody
    public Rigidbody2D corpo;
    //Animator
    public Animator animador;
    //instancia
    public static Movement instance = null;
    //Serial
    public SerialPort port = new SerialPort("COM5", 9600);
    int A1, B2, D1, D2, F1;
    String nota;
    // Notas
    public AudioSource Ocarina_D;
    public AudioSource Ocarina_D2;
    public AudioSource Ocarina_F;
    public AudioSource Ocarina_B;
    public AudioSource Ocarina_A;
    // Musicas
    public AudioSource BeliverSong;
    public AudioSource JoJoSong;
    public AudioSource Faroeste;
    public AudioSource FLindineaSong;
    public AudioSource OT8BitsSong;
    public AudioSource MusicaDeFundo;
    public AudioSource MarioMusic;
    public AudioSource SongOfHealingMusic;
    public AudioSource SongOfTime;
    public AudioSource MegalovaniaMusic;
    public AudioSource SongOfStorm;
    public AudioSource WIN;
    private AudioSource MusicaTocando;
    //Booleanos
    bool Help = false;
    public bool Rei = false;
    public bool Tranca1 = false;
    public bool Tranca2 = false;
    public bool Tranca3 = false;
    public bool tocado1 = false;
    public bool tocado2 = false;
    public bool tocado3 = false;
    public bool OcarinaMode = false;
    public bool StartPosit = true;
    public bool TrocaDeTela;
    bool tocando = false;
    public bool Casa;
    //Images
    Image Ocarinabase;
    Image A, D, E, C, B;
    //Vectors
    public Vector2 StartingPosition;
    // Numerals
    public float velocidade = 6;
    int[] Notas = new int[6];
    int QNTNotas = 0;
    public int TocandoProRei = 0;
    //Game Object
    public GameObject Sounds;
    public GameObject FandIN;
    public GameObject FandOUT;
    public GameObject FiltroSongOfHealing;
    //
    public GameObject Panel;

    void Start()
    {
        try
        {
            port.Open();
            port.ReadTimeout = 1;
            nota = "";
            A1 = 0;
            B2 = 0;
            F1 = 0;
            D1 = 0;
            D2 = 0;
        }
        catch (Exception)
        {
            nota = "";
        }
         // SetBardoForms
         corpo = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>(); 
        //Sound
        Sounds = GameObject.FindGameObjectWithTag("Sound");
        //Definição OcarinaBase
        Ocarinabase = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        //Definindo Notas
        A = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        D = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        C = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        B = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        E = GameObject.FindGameObjectWithTag("OcarinaBase").GetComponent<Image>();
        //Instanciamento
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
//// Vauvula de localização Startposit...
            if (StartPosit == true) {
            Debug.Log("Starting Position enter");

            if (SceneManage.instance.taEntrando) {
                transform.position = StartingPosition;
            } else {
                if(SceneManage.instance.lastPosition == Vector2.zero) {
                        transform.position = StartingPosition;
                }else {
                    transform.position = SceneManage.instance.lastPosition;
                }
            }
            
            Debug.Log(transform.position);  
            StartPosit = false;
        }
        ////  Fim da Vauvula

        //// Correr
        corpo.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidade = 6;
        }
        else
        {
            velocidade = 4;
        }

        //// Correr End


        //// Help Controller
        if (!Help)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameObject.transform.Find("CanvasHelp").gameObject.SetActive(true);
                gameObject.transform.Find("CanvasR").gameObject.SetActive(false);
                Help = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameObject.transform.Find("CanvasHelp").gameObject.SetActive(false);
                gameObject.transform.Find("CanvasR").gameObject.SetActive(true);
                Help = false;
            }
        }
//// Help Controller End
        


        if (OcarinaMode == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //GameObject Panel = Instantiate(FandIN, Vector3.zero, Quaternion.identity) as GameObject;
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
            try
            {
                nota = port.ReadByte().ToString();
                Debug.Log("Nota: " + nota);
                Debug.Log(A1 + " ," + B2 + " ," + F1 + " ," + D1 + " ," + D2);
            }
            catch (Exception)
            {
                nota = "";
                Debug.Log("Nao mandou");
            }

            if (nota.Equals("70"))
            {

                F1++;
                A1 = 0;
                B2 = 0;
                D2 = 0;
                D1 = 0;

            }
            else if (nota.Equals("68"))
            {

                D1++;
                A1 = 0;
                B2 = 0;
                D2 = 0;
                F1 = 0;
            }
            else if (nota.Equals("71"))
            {

                D2++;
                A1 = 0;
                B2 = 0;
                F1 = 0;
                D1 = 0;
            }
            else if (nota.Equals("66"))
            {

                B2++;
                A1 = 0;
                F1 = 0;
                D2 = 0;
                D1 = 0;
            }
            else if (nota.Equals("65"))
            {

                A1++;
                B2 = 0;
                F1 = 0;
                D2 = 0;
                D1 = 0;
            }
            
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
                MegalovaniaMusic.Stop();
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
                StartCoroutine(ExampleStopMusic(0.0f));
                StartCoroutine(ExampleLimp(0.0f));

            }
            else if (Input.GetKeyDown(KeyCode.H) || D1 == 3)
            {
                D1 = 0;
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
            else if (Input.GetKeyDown(KeyCode.I) || D2 == 3)
            {
                D2 = 0;
                Ocarina_D2.Play();         
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
            else if (Input.GetKeyDown(KeyCode.L) || A1 == 3)
            {
                A1 = 0;
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
            else if (Input.GetKeyDown(KeyCode.K) || F1 == 3)
            {
                F1 = 0;
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
            else if (Input.GetKeyDown(KeyCode.J) || B2 == 3)
            {
                B2 = 0;
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
                    if (Tranca1 == true)
                    {
                        if (Casa == false)
                        {
                                                
                            if (TocandoProRei == 3)
                            {
                                StartCoroutine(Example(WIN, 2.5f));
                                GameObject Tranca4 = GameObject.FindGameObjectWithTag("Portao4");
                                Tranca4.SetActive(false);
                                TocandoProRei = 0;
                            }else if (Rei)
                            {
                                TocandoProRei++;
                            }
                            else {
                            tocado1 = true;
                            StartCoroutine(Example(WIN, 2.5f));
                            GameObject Tranca1 = GameObject.FindGameObjectWithTag("Portao1");
                            Tranca1.SetActive(false);
                            }
                        }
                        Tranca1 = false;
                    }
                    //Panel = Instantiate(FiltroSongOfHealing, Vector3.zero, Quaternion.identity) as GameObject;
                    SongOfHealingMusic.Play();
                    tocando = true;
                    Destroy(Panel, 4);
                   // Debug.Log(TocandoProRei);
                }
                else if (Notas[0] == 1 && Notas[1] == 4 && Notas[2] == 2 && Notas[3] == 1 && Notas[4] == 4 && Notas[5] == 2)
                {
                    if (Tranca2 == true)
                    {
                        if (Casa == false)
                        {
                            if (TocandoProRei == 3)
                            {
                                
                                StartCoroutine(Example(WIN, 2.5f));
                                GameObject Tranca4 = GameObject.FindGameObjectWithTag("Portao4");
                                Tranca4.SetActive(false);
                                TocandoProRei = 0;
                            }
                            else if (Rei)
                            {
                                
                                TocandoProRei++;
                            }
                            else {
                           
                            tocado2 = true;
                            StartCoroutine(Example(WIN, 2.5f));
                            GameObject tranca2 = GameObject.FindGameObjectWithTag("Portao2");
                            tranca2.SetActive(false);
                            }
                        }
                        Tranca2 = false;
                    }
                    
                    SongOfStorm.Play();
                    tocando = true;
                    
                    Debug.Log(TocandoProRei);
                }
                else if (Notas[0] == 3 && Notas[1] == 1 && Notas[2] == 4 && Notas[3] == 3 && Notas[4] == 1 && Notas[5] == 4)
                {
                    if (Tranca3 == true)
                    {
                        if (Casa == false)
                        {
                            if (TocandoProRei == 3)
                            {
                                StartCoroutine(Example(WIN, 2.5f));
                                GameObject Tranca4 = GameObject.FindGameObjectWithTag("Portao4");
                                Tranca4.SetActive(false);
                                TocandoProRei = 0;
                            }
                            else if (Rei)
                            {
                                TocandoProRei++;
                            }
                            else {
                            tocado3 = true;
                            StartCoroutine(Example(WIN, 2.5f));
                            GameObject tranca3 = GameObject.FindGameObjectWithTag("Portao3");
                            tranca3.SetActive(false);
                            }
                            if (TocandoProRei == 3)
                            {
                                StartCoroutine(Example(WIN, 2.5f));
                                GameObject Tranca4 = GameObject.FindGameObjectWithTag("Portao4");
                                Tranca4.SetActive(false);
                                TocandoProRei = 0;
                            }
                        }
                        Tranca3 = false;
                    }
                    SongOfTime.Play();
                    tocando = true;
                    Debug.Log(TocandoProRei);
                }
                else if (Notas[0] == 1 && Notas[1] == 1 && Notas[2] == 2 && Notas[3] == 3 && Notas[4] == 4 && Notas[5] == 1)
                {
                    MegalovaniaMusic.Play();
                    tocando = true;
                    //HLkKhK Beliver/ HKLJLK JoJo // LILILK The good the bad the ugly // IIIHKL Flauta Lindinha // HHKILJ OT 8 - BITS 
                }
                else if (Notas[0] == 3 && Notas[1] == 2 && Notas[2] == 3 && Notas[3] == 2 && Notas[4] == 3 && Notas[5] == 4)
                {
                    Faroeste.Play();
                    tocando = true;
                }
                else if (Notas[0] == 1 && Notas[1] == 1 && Notas[2] == 4 && Notas[3] == 2 && Notas[4] == 3 && Notas[5] == 5)
                {
                    OT8BitsSong.Play();
                    tocando = true;
                }
                else if (Notas[0] == 1 && Notas[1] == 3 && Notas[2] == 4 && Notas[3] == 4 && Notas[4] == 1 && Notas[5] == 4)
                {
                    BeliverSong.Play();
                    tocando = true;
                }
                else if (Notas[0] == 1 && Notas[1] == 4 && Notas[2] == 3 && Notas[3] == 5 && Notas[4] == 3 && Notas[5] == 4)
                {
                    JoJoSong.Play();
                    tocando = true;
                }
                else if (Notas[0] == 2 && Notas[1] == 2 && Notas[2] == 2 && Notas[3] == 1 && Notas[4] == 4 && Notas[5] == 3)
                {
                    FLindineaSong.Play();
                    tocando = true;
                }
                if (QNTNotas == 6)
                    {
                    if (tocando == true)
                    {
                        //limpar
                        StartCoroutine(ExampleLimp(4.0f));
                    }
                    else
                    {
                        StartCoroutine(ExampleLimp(0.0f));
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
    IEnumerator ExampleStopMusic(float time)
    {
    BeliverSong.Stop();
    JoJoSong.Stop();
    Faroeste.Stop();
    FLindineaSong.Stop();
    OT8BitsSong.Stop();
    MusicaDeFundo.Stop();
    MarioMusic.Stop();
    SongOfHealingMusic.Stop();
    SongOfTime.Stop();
    MegalovaniaMusic.Stop();
    SongOfStorm.Stop();
    WIN.Stop();
    yield return new WaitForSeconds(time);
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
 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

