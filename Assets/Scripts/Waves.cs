using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public List<WaveData> waves;
    public int currentWave = 0;
    public float currentTimer = 0;
    public float countdownToNextWave;
    public float timeBetweenSpawns;

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
                StartCoroutine(SpawnNextWave());
        }
    }

    public bool IsLastWave()
    {
        return currentWave == waves.Count;
    }

    private IEnumerator SpawnNextWave()
    {
        currentTimer = 0;
        var waveToSpawn = currentWave;
        if (currentWave < waves.Count)
            currentWave++;
        GameEvents.FireWaveStarted(this, "");
        foreach (var member in waves[waveToSpawn].members)
        {
            for (int i = 0; i < member.amount; i++)
            {
                Instantiate(member.attacker, member.startPos.position, member.startPos.rotation);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
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