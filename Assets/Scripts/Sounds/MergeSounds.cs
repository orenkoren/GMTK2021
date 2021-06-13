using UnityEngine;

public class MergeSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource soundSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameEvents.MergeListeners += PlaySound;
    }

    private void PlaySound(object sender, string e)
    {
        //soundSource.pitch = Random.Range(0.9f, 1.1f);
        soundSource.clip = sounds[Random.Range(0, sounds.Length - 1)];
        soundSource.Play();
    }

    private void OnDestroy()
    {
        GameEvents.MergeListeners -= PlaySound;
    }
}
