using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxe : MonoBehaviour
{
    [Header("Plans")]
    [SerializeField] private GameObject plage;
    [SerializeField] private GameObject mer;
    [SerializeField] private GameObject nuage1;
    [SerializeField] private GameObject nuage2;
    [SerializeField] private GameObject ciel;

    [Header("Vitesse")]
    [SerializeField] private float vitessePlage;
    [SerializeField] private float vitesseMer;
    [SerializeField] private float vitesseNuage1;
    [SerializeField] private float vitesseNuage2;
    [SerializeField] private float vitesseCiel;

    private float limitePlage;
    private float limiteMer;
    private float limiteNuage1;
    private float limiteNuage2;
    private float limiteCiel;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        limitePlage = plage.transform.GetChild(0).transform.localPosition.x;
        limiteMer = mer.transform.GetChild(0).transform.localPosition.x;
        limiteNuage1 = nuage1.transform.GetChild(0).transform.localPosition.x;
        limiteNuage2 = nuage2.transform.GetChild(0).transform.localPosition.x;
        limiteCiel = ciel.transform.GetChild(0).transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        AppliquerParalaxe();
        GenerationInfinie();
    }

    private void AppliquerParalaxe()
    {
        plage.transform.Translate(Vector3.left * vitessePlage * Time.deltaTime);
        mer.transform.Translate(Vector3.left * vitesseMer * Time.deltaTime);
        nuage1.transform.Translate(Vector3.left * vitesseNuage1 * Time.deltaTime);
        nuage2.transform.Translate(Vector3.left * vitesseNuage2 * Time.deltaTime);
        ciel.transform.Translate(Vector3.left * vitesseCiel * Time.deltaTime);
    }

    private void GenerationInfinie()
    {
        Vector3 nvllePosition = Vector3.zero;
        if (plage.transform.localPosition.x <= -limitePlage) plage.transform.localPosition = nvllePosition;
        if (mer.transform.localPosition.x <= -limiteMer) mer.transform.localPosition = nvllePosition;
        nvllePosition.z = nuage1.transform.localPosition.z;
        if (nuage1.transform.localPosition.x <= -limiteNuage1) nuage1.transform.localPosition = nvllePosition;
        nvllePosition.z = nuage2.transform.localPosition.z;
        if (nuage2.transform.localPosition.x <= -limiteNuage2) nuage2.transform.localPosition = nvllePosition;
        nvllePosition.z = ciel.transform.localPosition.z;
        if (ciel.transform.localPosition.x <= -limiteCiel) ciel.transform.localPosition = nvllePosition;
    }
}
