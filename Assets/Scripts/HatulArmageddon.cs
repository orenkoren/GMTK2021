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

    void Update()
    {
        RaycastHit[] grandmas = Physics.SphereCastAll(transform.position, 500, transform.up, 0.1f, grandmaLayer, QueryTriggerInteraction.UseGlobal);
        float minGrandmaDistance = 5000;
        GameObject minGrandma = null;
        int previousAmount = grandmasAmount;
        grandmasAmount = grandmas.Length;
        foreach (var grandma in grandmas)
        {
            //NavMeshPath navPath = new NavMeshPath();
            //_navMeshAgent.CalculatePath(grandma.transform.position, navPath);
            //Vector3 current = transform.position;
            //var distance = 0f; // _navMeshAgent.remainingDistance
            //foreach (var node in navPath.corners)
            //{
            //    distance += Vector3.Distance(current, node);
            //}
            //if (distance < minGrandmaDistance || minGrandmaDistance == -1)
            //{
            //    minGrandmaDistance = distance;
            //    minGrandma = grandma.collider.gameObject;
            //}
            var dist = Vector3.Distance(grandma.point, transform.position);
            if (dist < minGrandmaDistance)
            {
                minGrandmaDistance = dist;
                minGrandma = grandma.collider.gameObject;
            }
        }

        if (minGrandma)
        {
            _navMeshAgent.SetDestination(minGrandma.transform.position);
        }
        //if (previousAmount <= grandmasAmount && minGrandmaDistance < 4)
        //{
        //    Destroy(minGrandma);
        //}
        var distToTarget = _navMeshAgent.destination - transform.position;
        if (new Vector3(distToTarget.x, 0, distToTarget.z).magnitude < 20f)
        {
            Destroy(minGrandma);
            Destroy(gameObject);
        }
        if (grandmas.Length == 0)
            Destroy(gameObject);
    }
}
