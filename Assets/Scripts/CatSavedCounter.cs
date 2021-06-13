using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSavedCounter : MonoBehaviour
{
    public int catsSaved;

    void Start()
    {
        GameEvents.CatSavedListeners += Increment;
    }

    private void Increment(object sender, string e)
    {
        catsSaved++;
    }

    private void OnDestroy()
    {
        GameEvents.CatSavedListeners -= Increment;
    }
}
