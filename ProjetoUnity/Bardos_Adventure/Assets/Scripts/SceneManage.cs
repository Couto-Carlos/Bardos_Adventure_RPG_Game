using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    //public Vector2[] ListStartMapPositions;
   public static SceneManage instance = null;
    public Vector2 lastPosition;
    public bool taEntrando;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;      
        }
        else if (instance != this)
        {
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
        }
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
