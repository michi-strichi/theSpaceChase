using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravityBodyNewMultiplayer : MonoBehaviour
{
    GameObject[] planets;
    Rigidbody rigidbody;
    private List<GravityAttractorNewMultiplayer> _attractors = new List<GravityAttractorNewMultiplayer>();
    private List<float> _planetsDistance = new List<float>();

    void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        rigidbody = GetComponent<Rigidbody>();

        foreach (var planet in planets)
        {
            _attractors.Add(planet.GetComponent<GravityAttractorNewMultiplayer>());
        }

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            _planetsDistance.Add(Vector3.Distance(transform.position, planets[i].transform.position));
        }
        
        
        float minVal = _planetsDistance.Min();
        int index = _planetsDistance.IndexOf(minVal);
        _attractors[index].Attract(rigidbody, -1 / _planetsDistance[index]*2000);
        _attractors[index].Reorient(rigidbody);
        _planetsDistance.Clear();
    }
}