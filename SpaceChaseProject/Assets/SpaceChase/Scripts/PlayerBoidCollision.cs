using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoidCollision : MonoBehaviour
{
    public SceneManagerSingleplayer sceneManager;
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Boid")
        {
            sceneManager.GameOver();
        }

    }
}
