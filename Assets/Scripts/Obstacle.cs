using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float vitesse;
    public Vector3 direction;


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
        SeProjeter();
    }

    private void SeProjeter()
    {
        transform.Translate(direction * vitesse * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out Cerfvolant cervolant))
        {
            cervolant.Blesser();
            SeDetruire();   
        }
        else if(collision.transform.TryGetComponent(out Bob bob))
        {
            bob.Blesser();
            SeDetruire();
        }
    }

    private void SeDetruire()
    {
        Destroy(gameObject);
    }
}
