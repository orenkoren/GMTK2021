using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hatul : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    [SerializeField] private GameObject _hatulArmageddon;
    private NavMeshAgent _navMeshAgent;
    private bool isTargeted;
    private ChoonkType type = ChoonkType.BIG;
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    }

    // Update is called once per frame
    void Update()
    {
        if ((_destination.transform.position - transform.position).magnitude < 5)
        {
            Instantiate(_hatulArmageddon, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void SetIsTargeted(bool targeted)
    {
        this.isTargeted = targeted;
    }

    public bool GetIsTargeted()
    {
        return this.isTargeted;
    }

    public void SetChoonkType(ChoonkType type)
    {
        this.type = type;
    }

    public ChoonkType GetChoonkType()
    {
        return this.type;
    }
}
