using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

    public Renderer[] rends;
    void Start()
    {
        Color buildingColor;

        rends = GetComponentsInChildren<Renderer>();
        buildingColor = new Color(Random.Range(.75f, 1), Random.Range(.75f, 1), Random.Range(.75f, 1));

        foreach (Renderer rend in rends)
        {
            rend.material.color = buildingColor;
        }

    }
    void Update()
    {
    }
}
