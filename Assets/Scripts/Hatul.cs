using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hatul : MonoBehaviour
{
    [SerializeField] private string endPosTag;
    private Transform _destination;
    [SerializeField] private GameObject _hatulArmageddon;
    [SerializeField] private ChoonkType type;
    private NavMeshAgent _navMeshAgent;
    private bool isTargeted;
    void Start()
    {
        _destination = GameObject.FindGameObjectWithTag(endPosTag).transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    }

    // Update is called once per frame
    void Update()
    {
        var dist = _destination.transform.position - transform.position;
        if (new Vector3(dist.x, 0, dist.z).magnitude < 20f)
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
