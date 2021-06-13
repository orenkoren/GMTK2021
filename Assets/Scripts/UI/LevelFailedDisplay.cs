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
        //StartCoroutine(EnableDisplay());
        Invoke("SetActive", 2);
    }

    private IEnumerator EnableDisplay()
    {
        yield return new WaitForSeconds(2);
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }
}
