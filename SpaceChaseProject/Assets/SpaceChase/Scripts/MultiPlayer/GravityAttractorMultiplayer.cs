using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class GravityAttractorMultiplayer : MonoBehaviour
{
    public float mouseSensitivityX = 20;
    public float gravity = 0f;
    public SceneManagerMultiplayer sceneManager;

    public void Attract(Rigidbody body)
    {
        if (sceneManager.IsPlaying())
        {
            Vector3 gravityUp = (body.position - transform.position).normalized;
            Vector3 localUp = body.transform.up;

            // Apply downwards gravity to body
            body.AddForce(gravityUp * gravity);
            // Allign bodies up axis with the centre of planet
            body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation * Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivityX, 0);
        }
    }
}