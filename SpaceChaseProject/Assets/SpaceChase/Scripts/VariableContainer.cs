using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableContainer : MonoBehaviour
{
    [HideInInspector] public String difficulty;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetDifficulty(String d)
    {
        difficulty = d;
    }
}
