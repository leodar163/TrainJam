using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCerfvolant : MonoBehaviour
{
    [SerializeField] private Cerfvolant cerfvolant;
    [SerializeField] private LineRenderer lineRend;
    [SerializeField] [Min(2)] private int segments;

    // Start is called before the first frame update
    void Start()
    {
        InitialiserFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        SimulerFileTendu();
    }

    private void InitialiserFile()
    {
        lineRend.positionCount = segments;
        
    }

    private void SimulerFileTendu()
    {
        lineRend.SetPosition(0, lineRend.transform.position);
        for (int i = 1; i < lineRend.positionCount; i++)
        {
            lineRend.SetPosition(i, Vector3.Lerp(cerfvolant.transform.position, lineRend.transform.position, i / lineRend.positionCount));
        }
    }
}
