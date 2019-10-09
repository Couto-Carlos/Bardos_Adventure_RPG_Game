using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefer : MonoBehaviour
{
    Transform Personagem;
    Transform Arvore;
   
    SpriteRenderer ArvoreSprite;
    SpriteRenderer PersonagemSprite;
    void Start()
    {
        Personagem = GameObject.Find("Link").GetComponent<Transform>();
        Arvore = GetComponent<Transform>();
        ArvoreSprite = GetComponent<SpriteRenderer>();
        PersonagemSprite = GameObject.Find("Link").GetComponent<SpriteRenderer>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Personagem.position.y > Arvore.position.y - 0.5f){
            ArvoreSprite.sortingOrder = PersonagemSprite.sortingOrder + 1;
        }
        else
        {
            ArvoreSprite.sortingOrder = PersonagemSprite.sortingOrder - 1;
        }
        
    }
}
