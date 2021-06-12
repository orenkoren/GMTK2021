using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitManager : MonoBehaviour
{
    public List<SplitData> splits;
    public Vector3 splitOffset;

    private void Start()
    {
        GameEvents.ObjectRightClickListeners += SplitIfPossible;
    }

    private void SplitIfPossible(object sender, int e)
    {
        GameObject senderObj = ((GameObject)sender);
        foreach (var split in splits)
        {
            var tag = senderObj.tag;
            if (split.parentTag == tag)
            {
                Destroy(senderObj);
                Instantiate(split.splitsInto, senderObj.transform.position, senderObj.transform.rotation);
                Instantiate(split.splitsInto,
                    senderObj.transform.position + splitOffset, senderObj.transform.rotation);
            }
        }
    }
}

[Serializable]
public class SplitData
{
    public string parentTag;
    public GameObject splitsInto;
}