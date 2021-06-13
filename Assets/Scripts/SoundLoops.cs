using System;
using System.Collections;
using UnityEngine;

public class SoundLoops : MonoBehaviour
{
    public AudioClip betweenWaves;
    public AudioClip daytime;
    public AudioClip nighttime;
    public AudioClip transition;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameEvents.WaveStartedListeners += PlayWaveStarted;
        GameEvents.WaveFinishedListeners += PlayWaveFinished;
        GameEvents.WavePhasedListeners += PlayTransitionAndThenNightime;
    }

    private void PlayTransitionAndThenNightime(object sender, string e)
    {
        
    }

    private void PlayWaveFinished(object sender, string e)
    {
        //if (source.clip != daytime)
        //    StartCoroutine(FadeAndPlayNext(daytime));
    }

    private void PlayWaveStarted(object sender, string e)
    {
        //if (source.clip != daytime)
        //    StartCoroutine(FadeAndPlayNext(daytime));
    }

    private IEnumerator FadeAndPlayNext(AudioClip nextClip)
    {
        float currentTime = 0;
        float duration = 3f;
        float start = source.volume;
        float targetVolume = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        source.Stop();
        source.volume = start;
        source.PlayOneShot(nextClip);
    }

    private void OnDestroy()
    {
        GameEvents.WaveStartedListeners -= PlayWaveStarted;
        GameEvents.WaveFinishedListeners -= PlayWaveFinished;
        GameEvents.WavePhasedListeners -= PlayTransitionAndThenNightime;
    }
}
