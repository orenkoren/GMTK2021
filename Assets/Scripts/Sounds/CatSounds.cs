using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource soundSource;
    public float interval;
    private float counter;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > interval)
        {
            PlaySound();
            counter = 0;
        }
    }


    private void PlaySound()
    {
        soundSource.pitch = Random.Range(0.9f, 1.1f);
        soundSource.clip = sounds[Random.Range(0, sounds.Length - 1)];
        soundSource.Play();
    }
}
