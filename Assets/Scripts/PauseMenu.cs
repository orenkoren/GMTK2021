using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public AudioMixer audioMixer;
    public static bool paused = false;
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        ui.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        ui.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ChangeVolume(float value)
    {
        print(value);
        audioMixer.SetFloat("volume", value);
    }
}
