using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    int size = 20;
    
    Transform[] points;
    public Transform buildingObject;
    public GameObject roads;

    // Start is called before the first frame update
    void Start()
    {
        float offset = size / 2;    
        // points = new Transform[size];
        
        // use roads game object
        // get roads.children
        // for each road 
            // for length 

        // for (int i = 0; i < size; i += 1) {
            
            // float height = Random.Range(1.0f,2.0f);
            // Transform building = Instantiate(buildingObject);
            // building.localScale = new Vector3(0.5f,height,0.5f);
            // building.localPosition = new Vector3(i - offset, height, 0);
            // building.SetParent(transform, false);
            // points[i] = building;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
