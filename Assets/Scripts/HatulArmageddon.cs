using UnityEngine;
using UnityEngine.AI;

public class HatulArmageddon : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public LayerMask grandmaLayer;
    void Start()
    {

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit[] grandmas = Physics.SphereCastAll(transform.position, 150, transform.up, 0.1f, grandmaLayer, QueryTriggerInteraction.UseGlobal);
        float minGrandmaDistance = -1;
        GameObject minGrandma = null;
        foreach (var grandma in grandmas)
        {
            NavMeshPath navPath = new NavMeshPath();
            _navMeshAgent.CalculatePath(grandma.transform.position, navPath);
            if (_navMeshAgent.remainingDistance < minGrandmaDistance || minGrandmaDistance == -1)
            {
                minGrandmaDistance = _navMeshAgent.remainingDistance;
                minGrandma = grandma.collider.gameObject;
            }
        }

        if (minGrandma)
        {
            _navMeshAgent.SetDestination(minGrandma.transform.position);
        }

        if (minGrandmaDistance > 0 && minGrandmaDistance < 0.5)
        {
            Destroy(minGrandma);
        }
    }
}
