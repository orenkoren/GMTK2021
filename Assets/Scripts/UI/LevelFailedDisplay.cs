using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailedDisplay : MonoBehaviour
{
    void Start()
    {
        GameEvents.LevelFailedListeners += EnableDisplay;
        gameObject.SetActive(false);
    }

    private void EnableDisplay(object sender, string e)
    {
        gameObject.SetActive(true);
    }
}
