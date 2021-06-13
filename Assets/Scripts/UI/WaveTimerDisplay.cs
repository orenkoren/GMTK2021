using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimerDisplay : MonoBehaviour
{
    public Waves waveSpawner;
    public Text waveSeconds;
    public Text regularCatAmount;
    public Text megaCatAmount;

    private void Start()
    {
        GameEvents.WaveFinishedListeners += UpdateWaveInfo;
        GameEvents.WaveStartedListeners += UpdateWaveInfo;
    }

    private void Update()
    {

        if (waveSpawner.countdownToNextWave >= 0)
        {
            waveSeconds.text = ((int)waveSpawner.countdownToNextWave).ToString();
        }
    }

    private void UpdateWaveInfo(object sender, string e)
    {
        regularCatAmount.text = "";
        megaCatAmount.text = "";
        if (waveSpawner.currentWave == waveSpawner.waves.Count)
            return;
        var members = waveSpawner.waves[waveSpawner.currentWave].members;
        regularCatAmount.text = members[0].amount.ToString();
        megaCatAmount.text = members[1].amount.ToString();
    }

    private void OnDestroy()
    {
        GameEvents.WaveFinishedListeners -= UpdateWaveInfo;
        GameEvents.WaveStartedListeners -= UpdateWaveInfo;
    }

}
