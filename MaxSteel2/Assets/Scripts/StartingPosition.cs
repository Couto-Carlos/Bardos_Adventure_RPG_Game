using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPosition : MonoBehaviour
{
    public Vector2 Position;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Bardo = GameObject.FindGameObjectWithTag("Link").gameObject;
        Bardo.GetComponent<Movement>().StartPosit = true;
        Bardo.GetComponent<Movement>().StartingPosition = Position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
