using System;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public List<WaveData> waves;
    public int currentWave = 0;
    public float currentTimer = 0;
    public float countdownToNextWave;

    private void Start()
    {
        GameEvents.FireWaveFinished(this, "");
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentWave < waves.Count)
        {
            countdownToNextWave = waves[currentWave].intervalBeforeWave - currentTimer;

            if (currentTimer >= waves[currentWave].intervalBeforeWave)
                SpawnNextWave();
        }
    }

    public bool IsLastWave()
    {
        return currentWave == waves.Count;
    }

    private void SpawnNextWave()
    {
        currentTimer = 0;
        foreach (var member in waves[currentWave].members)
        {
            for (int i = 0; i < member.amount; i++)
            {
                var e = Instantiate(member.attacker, member.startPos.position, member.startPos.rotation);
                //Destroy(e, 5);
            }
        }
        if (currentWave < waves.Count)
            currentWave++;
        GameEvents.FireWaveStarted(this, "");

    }
}

[Serializable]
public class WaveData
{
    public float intervalBeforeWave;
    public List<WaveMember> members;
}

[Serializable]
public class WaveMember
{
    public GameObject attacker;
    public Transform startPos;
    public int amount;
}