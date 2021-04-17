using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] private int scoreParSeconde;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
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
            score += scoreParSeconde;
        }
    }
}
