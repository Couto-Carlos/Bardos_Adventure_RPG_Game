using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{


    Transform Personagem;
    Transform CameraPosicao;
    Vector3 diferenca;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Start()
    {
        Personagem = GameObject.Find("Link").GetComponent<Transform>();

        CameraPosicao = GetComponent<Transform>();
        diferenca = CameraPosicao.position - Personagem.position ; 
    }

   
    void FixedUpdate()
    {
        if(CameraPosicao.position != Personagem.position){
         Vector3 targetPosition = new Vector3(Personagem.position.x, Personagem.position.y, CameraPosicao.position.z);

         targetPosition.x = Mathf.Clamp(targetPosition.x,
         minPosition.x,
         maxPosition.x
         );
         targetPosition.y = Mathf.Clamp(targetPosition.y,
         minPosition.y,
         maxPosition.y
         );

        CameraPosicao.position = Vector3.Lerp(CameraPosicao.position, targetPosition, 1);   

        }
    }
}
