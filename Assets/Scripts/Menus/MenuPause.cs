using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public Button boutonPause;

    private bool estOuvert = true;

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

    public void BasculerMenu()
    {
        estOuvert = !estOuvert;
        Time.timeScale = estOuvert ? 0 : 1;
        boutonPause.gameObject.SetActive(!estOuvert);
        Menu.SetActive(estOuvert);
    }
}
