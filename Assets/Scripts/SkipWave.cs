using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipWave : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SkipWaveLogic();
        }
    }

    private void SkipWaveLogic()
    {
        GetComponent<Waves>().currentTimer = 5000;
    }
}
