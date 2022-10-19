using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GravityAttractorNew : MonoBehaviour
{
    public float mouseSensitivityX = 20;
    public SceneManagerSingleplayer sceneManager;

    public void Attract(Rigidbody body, float gravity)
    {
        if (sceneManager.IsPlaying())
        {
            Vector3 gravityUp = (body.position - transform.position).normalized;
            body.AddForce(gravityUp * gravity);
        }
    }

    public void Reorient(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;
        Quaternion newRotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation *
                                 Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivityX, 0);
        body.rotation = Quaternion.Lerp(body.transform.rotation, newRotation, 0.8f);
    }
}