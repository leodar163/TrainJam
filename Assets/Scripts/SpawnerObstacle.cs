using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstacles;
    [SerializeField] private Transform[] pointsSpawn;
    [SerializeField][Min(0.01f)] private float rayon;
    [SerializeField] private Vector3 direction;
    private Vector3 perpendiculaireDirection
    {
        get
        {
            direction.Normalize();
            return new Vector3(-direction.y, direction.x, 0);
        }
    }
    [SerializeField] private float vitesseInitiale;
    [SerializeField] private float vitesseMax;
    [SerializeField] private float aleaVitesse;
    [SerializeField] private float frequenceInitiale;
    [SerializeField] private float frequenceMin;
    [SerializeField] private float aleaFrequence;
    private enum ModeSpawn { etendue, point};

    [SerializeField] private ModeSpawn modeSpawn = ModeSpawn.point;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < pointsSpawn.Length; i++)
        {
            Vector3 position = pointsSpawn[i].position;
            if (modeSpawn == ModeSpawn.etendue)
            {
                Gizmos.DrawLine(position - perpendiculaireDirection * rayon, position + perpendiculaireDirection * rayon);
            }
            else
            {
                Gizmos.DrawWireSphere(position, rayon);
            }
            Gizmos.DrawLine(position, position + direction);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoutineSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RoutineSpawn()
    {
        float temps = 0 ;
        float tempsCible = Random.Range(frequenceInitiale - aleaFrequence - Mathf.Log10(Time.realtimeSinceStartup)
            , frequenceInitiale + aleaFrequence - Mathf.Log10(Time.realtimeSinceStartup));
        tempsCible = Mathf.Max(frequenceMin, tempsCible);
        while (temps < tempsCible)
        {
            yield return new WaitForEndOfFrame();
            temps += Time.deltaTime;
        }
        SpawnObstacle();
        StartCoroutine(RoutineSpawn());
    }

    private void SpawnObstacle()
    {
        Vector3 position = pointsSpawn[Random.Range(0, pointsSpawn.Length)].position;
        Vector3 aleaDecalage;

        if (modeSpawn == ModeSpawn.etendue)
        {
            aleaDecalage = Vector3.Lerp(-perpendiculaireDirection * rayon, perpendiculaireDirection * rayon, Random.Range(0f, 1f));
        }
        else
        {
            aleaDecalage = Random.insideUnitCircle * Random.Range(0, rayon);
        }
        position += aleaDecalage;

        int alea = Random.Range(0, obstacles.Length);
        if(Instantiate(obstacles[alea]).TryGetComponent(out Obstacle obstacle))
        {
            obstacle.direction = direction;
            obstacle.vitesse += Mathf.Min(vitesseMax,Random.Range(vitesseInitiale + Mathf.Log10(Time.realtimeSinceStartup) - aleaVitesse
                , vitesseInitiale + Mathf.Log10(Time.realtimeSinceStartup) + aleaVitesse));
            obstacle.transform.position = position;
        }
    }
}
