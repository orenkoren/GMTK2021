using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassed : MonoBehaviour
{
    void Start()
    {
        GameEvents.LevelFinishedListeners += EnableDisplay;
        gameObject.SetActive(false);
    }

    private void EnableDisplay(object sender, string e)
    {
        Invoke("SetActive", 2);
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }
}
