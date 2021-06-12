using UnityEngine;
using UnityEngine.AI;

public class HatulArmageddon : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public LayerMask grandmaLayer;
    private int grandmasAmount = 0; // POS hack
    void Start()
    {

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit[] grandmas = Physics.SphereCastAll(transform.position, 500, transform.up, 0.1f, grandmaLayer, QueryTriggerInteraction.UseGlobal);
        float minGrandmaDistance = -1;
        GameObject minGrandma = null;
        int previousAmount = grandmasAmount;
        grandmasAmount = grandmas.Length;
        foreach (var grandma in grandmas)
        {
            NavMeshPath navPath = new NavMeshPath();
            _navMeshAgent.CalculatePath(grandma.transform.position, navPath);
            Vector3 current = transform.position;
            var distance = 0f; // _navMeshAgent.remainingDistance
            foreach (var node in navPath.corners)
            {
                distance += Vector3.Distance(current, node);
            }
            if (distance < minGrandmaDistance || minGrandmaDistance == -1)
            {
                minGrandmaDistance = distance;
                minGrandma = grandma.collider.gameObject;
            }
        }

        if (minGrandma)
        {
            _navMeshAgent.SetDestination(minGrandma.transform.position);
        }
        if (previousAmount <= grandmasAmount && minGrandmaDistance < 4)
        {
            Destroy(minGrandma);
        }
    }
}
