using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoubellleObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 taille;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, taille);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        VerifCollisions();
    }

    private void VerifCollisions()
    {
        Collider2D[] collisions = Physics2D.OverlapBoxAll(transform.position, taille, 0);

        for (int i = 0; i < collisions.Length; i++)
        {
            if(collisions[i].TryGetComponent(out Obstacle obstacle))
            {
                Destroy(obstacle.gameObject);
            }
        }
    }
}
