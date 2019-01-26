using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    int size = 20;
    Transform[] points;
    public Transform buildingObject;

    // Start is called before the first frame update
    void Start()
    {
        
        points = new Transform[size];
        
        for (int i = 0; i < size; i += 2)
        {
            Transform point = Instantiate(buildingObject);
            point.localScale = new Vector3(1,1,1);
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
