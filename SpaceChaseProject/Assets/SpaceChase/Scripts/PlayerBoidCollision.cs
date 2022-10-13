using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoidCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Boid")
        {
            Debug.Log("Collided with boid!!");
        }

    }
}
