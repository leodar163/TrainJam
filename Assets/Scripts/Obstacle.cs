using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float vitesse;
    public Vector3 direction;
    [Header("FeedBack")]
    [SerializeField] ParticleSystem fbCol;
    [SerializeField] Color couleurFB;

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
        transform.Translate(direction * vitesse * Time.fixedDeltaTime, Space.World);
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
        if(Instantiate(fbCol.gameObject).TryGetComponent(out ParticleSystem partSys))
        {
            partSys.transform.position = transform.position;
            ParticleSystem.MainModule main = partSys.main;
            main.startColor = couleurFB;
        }
        Destroy(gameObject);
    }
}
