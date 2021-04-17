using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerfvolant : MonoBehaviour
{
    public QueueCerfVolant queue;
    [SerializeField] private float vitesseRotation = 1f;
    [SerializeField] private float vitessemouvement = 1f;
    [SerializeField] private ZoneCerfvolant zoneCerfvolant;
    [SerializeField] [Min(1)] private int pV = 1;
    public int PV
    {
        get
        {
            return pV;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LimiterHauteurSouris(ref positionSouris);
        RegarderSouris(positionSouris);
        SuivreSouris(positionSouris);
    }

    private void LimiterHauteurSouris(ref Vector2 positionSouris)
    {
        positionSouris.y = Mathf.Max(zoneCerfvolant.MinHauteur, positionSouris.y);
        positionSouris.y = Mathf.Min(zoneCerfvolant.MaxHauteur, positionSouris.y);
    }

    private void RegarderSouris(Vector2 positionSouris)
    {
        Vector2 direction = (Vector2)transform.position - positionSouris;

        direction.x = -Mathf.Abs(direction.x);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, vitesseRotation * Time.deltaTime);
    }

    private void SuivreSouris(Vector2 positionSouris)
    {
        float distanceSouris = Vector2.Distance(transform.position, positionSouris);

        Vector3 position = Vector3.MoveTowards(transform.position, positionSouris, distanceSouris * vitessemouvement * Time.deltaTime);
        position.x = transform.position.x;
        position.z = transform.position.z;

        transform.position = position;
    }

    public void Blesser(int degats = 1)
    {
        pV = Mathf.Max(0, pV - degats);
        if (pV <= 0) GameManager.GameOver();
        else
            for (int i = 0; i < degats; i++)
            {
                queue.RetirerSection();
            }
        
    }

    public void Soigner(int soin = 1)
    {
        pV += soin;
    }
}
