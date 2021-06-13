using TMPro;
using UnityEngine;

public class WaveTimerDisplay : MonoBehaviour
{
    public Waves waveSpawner;
    public TextMeshProUGUI text;
    public TextMeshProUGUI waveInfo;

    private void Start()
    {
        GameEvents.WaveFinishedListeners += UpdateWaveInfo;
        GameEvents.WaveStartedListeners += UpdateWaveInfo;
    }

    private void Update()
    {

        if (waveSpawner.countdownToNextWave >= 0)
        {
            text.text = ((int)waveSpawner.countdownToNextWave).ToString();
        }
    }

    private void UpdateWaveInfo(object sender, string e)
    {
        waveInfo.text = "";
        if (waveSpawner.currentWave == waveSpawner.waves.Count)
            return;
        foreach (var member in waveSpawner.waves[waveSpawner.currentWave].members)
        {
            waveInfo.text += member.amount + " " + member.attacker.name + " ";
        }
    }

    private void OnDestroy()
    {
        GameEvents.WaveFinishedListeners -= UpdateWaveInfo;
        GameEvents.WaveStartedListeners -= UpdateWaveInfo;
    }

}
