using System;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public List<MergeData> merges;

    private void Update()
    {
        MergeIfPossible();
    }

    private void MergeIfPossible()
    {
        if (GameEvents.FirstSelectedObject && GameEvents.SecondSelectedObject)
        {
            if(GameEvents.FirstSelectedObject.tag == GameEvents.SecondSelectedObject.tag)
            {
                var tag = GameEvents.FirstSelectedObject.tag;
                foreach (var possibleMerge in merges)
                {
                    if (possibleMerge.coupleOfTag == tag)
                    {
                        Destroy(GameEvents.FirstSelectedObject);
                        Destroy(GameEvents.SecondSelectedObject);
                        Instantiate(possibleMerge.result,
                            GameEvents.SecondSelectedObject.transform.position,
                            GameEvents.SecondSelectedObject.transform.rotation);
                        GameEvents.FireSelectionCleared(this, 0);
                    }
                }
            }
        }
    }
}

[Serializable]
public class MergeData
{
    public string coupleOfTag;
    public GameObject result;
}