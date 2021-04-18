using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDebut : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI annonceScore;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        annonceScore.text = "RECORD : " + PlayerPrefs.GetInt("Score");
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

    public void Jouer()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
