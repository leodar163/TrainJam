using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    public float pas = 0.1f;
    private void OnDrawGizmos()
    {
        
        for (float i = 0; i < 200; i+=pas)
        {
            Gizmos.DrawLine(new Vector3(i - pas, Mathf.Log(i - pas)), new Vector3(i, Mathf.Log(i)));
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
}
