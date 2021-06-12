using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SpriteDirection : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Image image;
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = navMeshAgent.velocity.x;
        if (dir != 0)
        {
            var org = image.rectTransform.localScale;
            org.x = -dir / Mathf.Abs(dir);
            image.rectTransform.localScale = org;
        }
    }
}
