using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI annonceScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quitter()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
    }

    public void OuvrirMenu(bool scoreBattu)
    {
        Time.timeScale = 0;
        if(scoreBattu)
        {
            annonceScore.text = string.Format("NOUVEAU RECORD : {0}", Scoring.Instance.Score);
        }
        else
        {
            annonceScore.text = string.Format("RECORD : {0}", Scoring.Instance.Score);
        }

        gameObject.SetActive(true);
    }

    public void Rejouer()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
