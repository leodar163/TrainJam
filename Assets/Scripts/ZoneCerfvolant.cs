using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCerfvolant : MonoBehaviour
{
    public float MaxHauteur;
    public float MinHauteur;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(-10, MaxHauteur), new Vector3(10, MaxHauteur));
        Gizmos.DrawLine(new Vector3(-10, MinHauteur), new Vector3(10, MinHauteur));
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
