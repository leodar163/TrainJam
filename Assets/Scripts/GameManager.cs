using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager cela;

    public static GameManager Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<GameManager>();
            return cela;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void GameOver()
    {

    }
}
