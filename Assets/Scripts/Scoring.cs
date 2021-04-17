using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    static private Scoring cela;

    static public Scoring Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<Scoring>();
            return cela;
        }
    }

    [SerializeField] private int scoreParSeconde;
    [SerializeField] private GameObject feedBackScore;
    [SerializeField] private Transform positionTemps;
    [SerializeField] private Transform positionCerfPerdu;
    [SerializeField] private TextMeshProUGUI compteScore;

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoutineScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RoutineScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            GagnerScore(scoreParSeconde);
        }
    }

    public void GagnerScore(int scoreGagne, bool cerfPerdu = false)
    {
        score += scoreGagne;
        Transform trans = cerfPerdu ? positionCerfPerdu : positionTemps;
        GameObject fbScore = Instantiate(feedBackScore, trans);

        if (fbScore.TryGetComponent(out TextMeshProUGUI text))
        {
            text.text = "+" + scoreGagne;
            StartCoroutine(DetruireFeedBack(fbScore));
        }
        compteScore.text = string.Format("Score : {0}", score);
    }

    private IEnumerator DetruireFeedBack(GameObject feedBack)
    {
        yield return new WaitForSeconds(2);
        Destroy(feedBack);
    }
}
