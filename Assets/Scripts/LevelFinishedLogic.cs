using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishedLogic : MonoBehaviour
{
    public string[] enemyTags;
    public Waves waveSpawner;

    void Update()
    {
        if (CheckLevelFinished())
            GameEvents.FireLevelFinished(this, "");
    }

    private bool CheckLevelFinished()
    {
        if (waveSpawner.IsLastWave() == false)
            return false;
        foreach (var tag in enemyTags)
        {
            if (GameObject.FindGameObjectsWithTag(tag).Length != 0)
                return false;
        }
        return true;
    }
}
