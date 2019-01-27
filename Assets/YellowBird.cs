using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird {

    // Use this for initialization
    float offset;
    public override void Start () {
        base.Start();
        offset = Random.Range(4,9) / 10;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //PathingController.get_instance().query_graph( Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y));
    }
}
