using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravityBodyMultiplayer : MonoBehaviour
{
    GameObject[] planets;
    Rigidbody rigidbody;
    private List<GravityAttractorMultiplayer> _attractors = new List<GravityAttractorMultiplayer>();

    void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (var planet in planets)
        {
            _attractors.Add(planet.GetComponent<GravityAttractorMultiplayer>());
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