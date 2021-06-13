using UnityEngine;

public class LevelFinishedLogic : MonoBehaviour
{
    public string[] enemyTags;
    public string[] grandmaTags;
    public Waves waveSpawner;

    void Update()
    {
        if (CheckLevelFinished())
            GameEvents.FireLevelFinished(this, "");
        if (CheckLevelFailed())
            GameEvents.FireLevelFailed(this, "");
    }

    private bool CheckLevelFailed()
    {
        if (waveSpawner.IsLastWave() == false)
            return false;
        foreach (var tag in grandmaTags)
        {
            if (GameObject.FindGameObjectsWithTag(tag).Length > 0)
            {
                return false;
            }
        }
        return true;
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
        foreach (var tag in grandmaTags)
        {
            if (GameObject.FindGameObjectsWithTag(tag).Length == 0)
            {
                return false;
            }
        }
        return true;
    }
}
