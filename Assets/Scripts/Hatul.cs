using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hatul : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    [SerializeField] private GameObject _hatulArmageddon;
    private NavMeshAgent _navMeshAgent;
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(_destination.transform.position - transform.position) < 3)
        {
            Instantiate(_hatulArmageddon, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
