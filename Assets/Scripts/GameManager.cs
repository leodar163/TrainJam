using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager cela;
    [SerializeField] private MenuDebut menuDebut;
    [SerializeField] private MenuGameOver menuGameOver;
    [SerializeField] private MenuPause menuPause;

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
        Init();
    }

    private void Init()
    {

        menuGameOver.gameObject.SetActive(false);
        menuPause.BasculerMenu();

        GameObject[] musiques = GameObject.FindGameObjectsWithTag("Musique");
        AudioSource musiqueAGarder = musiques[0].GetComponent<AudioSource>();
        foreach (GameObject go in musiques)
        {
            if(go.TryGetComponent(out AudioSource musique))
            {
                if(musique.isPlaying)
                {
                    musiqueAGarder = musique;
                    break;
                }
            }
        }
        foreach (GameObject go in musiques)
        {
            if (go.TryGetComponent(out AudioSource musique))
            {
                if (musique != musiqueAGarder)
                {
                    Destroy(musique.gameObject);
                }
            }
        }
        if (!musiqueAGarder.isPlaying) musiqueAGarder.Play();
        DontDestroyOnLoad(musiqueAGarder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void GameOver()
    {
        bool meilleurScoreBattu = PlayerPrefs.GetInt("Score") < Scoring.Instance.Score;
        Instance.menuGameOver.OuvrirMenu(meilleurScoreBattu);

        if (meilleurScoreBattu) PlayerPrefs.SetInt("Score", Scoring.Instance.Score);
    }
}
