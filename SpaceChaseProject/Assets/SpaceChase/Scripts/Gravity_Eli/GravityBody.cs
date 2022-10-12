using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GameObject[] planets;
    Rigidbody rigidbody;
    private List<GravityAttractor> _attractors = new List<GravityAttractor>();

    void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (var planet in planets)
        {
            _attractors.Add(planet.GetComponent<GravityAttractor>());
        }

        rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        foreach (var attractor in _attractors)
        {
            if (attractor.gravity < 0)
            {
                attractor.Attract(rigidbody);
            }
        }
    }
}