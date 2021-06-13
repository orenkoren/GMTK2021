using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SpriteDirection : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    SpriteRenderer sprite;
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = navMeshAgent.velocity.x;
        if (dir != 0)
        {
            // var org = sprite.rectTransform.localScale;
            // org.x = -dir / Mathf.Abs(dir);

            if(dir < 0) {
                sprite.flipX = true;
            } else if(dir > 0) {
                sprite.flipX = false;
            }
        }
    }
}
