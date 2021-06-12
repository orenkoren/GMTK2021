using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public List<WaveData> waves;
    private int currentWave = 0;
    public float currentTimer = 0;

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentWave < waves.Count && currentTimer >= waves[currentWave].intervalBeforeWave)
            SpawnNextWave();
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
        currentWave++;

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