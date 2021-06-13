using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public float startAfterTime;
    public float fadeTimer;
    private SpriteRenderer inst;
    private float startCounter = 0;
    private bool hasTriggered = false;

    void Start()
    {
        inst = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        startCounter += Time.deltaTime;
        if (!hasTriggered && startCounter > startAfterTime)
        {
            StartCoroutine(SpawnInstruction());
            hasTriggered = true;
        }
    }

    private IEnumerator SpawnInstruction()
    {
        float counter = 0;
        inst.color = new Color(inst.color.r, inst.color.g, inst.color.b, 0);
        inst.enabled = true;
        while(counter < fadeTimer)
        {
            inst.color = new Color(inst.color.r, inst.color.g, inst.color.b,
                Mathf.Lerp(0, 1, counter / fadeTimer));
            counter += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float counter = 0;
        inst.color = new Color(inst.color.r, inst.color.g, inst.color.b, 1);
        inst.enabled = true;
        while (counter < fadeTimer)
        {
            inst.color = new Color(inst.color.r, inst.color.g, inst.color.b,
                Mathf.Lerp(1, 0, counter / fadeTimer));
            counter += Time.deltaTime;
            yield return null;
        }

        inst.enabled = false;
    }
}
