using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoid : MonoBehaviour
{
    public float rotateSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotateSpeed);
    }
}
