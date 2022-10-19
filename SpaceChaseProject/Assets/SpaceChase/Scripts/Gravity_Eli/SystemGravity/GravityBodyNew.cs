using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravityBodyNew : MonoBehaviour
{
    GameObject[] planets;
    Rigidbody rigidbody;
    private List<GravityAttractorNew> _attractors = new List<GravityAttractorNew>();
    private List<float> _planetsDistance = new List<float>();

    void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        rigidbody = GetComponent<Rigidbody>();

        foreach (var planet in planets)
        {
            _attractors.Add(planet.GetComponent<GravityAttractorNew>());
        }

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            _planetsDistance.Add(Vector3.Distance(transform.position, planets[i].transform.position));
            float gravity = -1 / _planetsDistance[i] * 750;
            
            /*if (gravity > -5f)
            {
                gravity = -5f;
            }
            Debug.Log(gravity);*/
            
            _attractors[i].Attract(rigidbody, gravity);
        }
        
        float minVal = _planetsDistance.Min();
        int index = _planetsDistance.IndexOf(minVal);
        _attractors[index].Reorient(rigidbody);
        _planetsDistance.Clear();
    }
}