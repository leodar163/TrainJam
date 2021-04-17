using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerfPerdu : MonoBehaviour
{
    private bool estTrouvee = false;
    public float vitesse;
    public Vector3 direction;
    [SerializeField] private Collider2D col;
    [SerializeField] private int gainScore;
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
       if (!estTrouvee) SeProjeter();
    }

    private void SeProjeter()
    {
        transform.Translate(direction * vitesse * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent(out Cerfvolant cerfvolant))
        {
            estTrouvee = true;
            transform.parent = cerfvolant.queue.transform;
            cerfvolant.queue.AjouterSection(this);
            cerfvolant.Soigner();
            col.enabled = false;
            Scoring.Instance.GagnerScore(gainScore, true);
        }
    }

    public void FaireLaQueue(Vector3 postion, Vector3 cible)
    {
        transform.position = postion;
        Vector3 direction = cible - postion;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
