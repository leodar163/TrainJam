using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform sprite;
    [SerializeField] private float forceSaut;
    [SerializeField] private float forceAtterrissage;
    [SerializeField] private Cerfvolant cerfvolant;
    private bool estAccroupi = false;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - transform.up * 0.1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AffecterControles();
    }

    private void FixedUpdate()
    {
        
    }

    private void AffecterControles()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(EstAuSol() && !estAccroupi)
            {
                rb.AddForce(transform.up * forceSaut);
            }
        }
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if(EstAuSol())
            {
                sprite.localScale = new Vector3(1, 1, 1);
                sprite.localPosition = new Vector3(0, 0.5f, 0);
                estAccroupi = true;
            }
            else
            {
                rb.AddForce(-transform.up * forceAtterrissage * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(EstAuSol())
            {
                sprite.localScale = new Vector3(1, 2, 1);
                sprite.localPosition = new Vector3(0, 1, 0);
                estAccroupi = false;
            }
        }
    }

    private bool EstAuSol()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.up, 0.15f, LayerMask.GetMask("Sol"));
        if(ray.collider)
        {
            return true;
        }
        return false;
    }

    public void Blesser(int degats = 1)
    {
        if (cerfvolant.PV > 0)
        {
            cerfvolant.Blesser(degats);
        }
    }
}
