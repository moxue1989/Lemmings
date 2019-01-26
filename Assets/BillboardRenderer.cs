using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardRenderer : MonoBehaviour
{
    // Assignment
    public Transform BillboardCameraTransform;
    private Transform BillboardTransform;
    // Start is called before the first frame update
    void Start()
    {
        BillboardCameraTransform = Camera.main.transform;
        BillboardTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        BillboardTransform.forward = -BillboardCameraTransform.forward;
    }
}
