using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaSpawner : MonoBehaviour
{
    [SerializeField] private float grandmaSpacing = 3;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask grandmaLayer;
    [SerializeField] private GameObject grandma;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMousePosition();
            RaycastHit[] hits = Physics.SphereCastAll(mousePosition, grandmaSpacing, transform.up, 0.1f, grandmaLayer, QueryTriggerInteraction.UseGlobal);

            if (mousePosition != Vector3.zero && hits.Length == 0)
            {
                Instantiate(grandma, mousePosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, groundLayer))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
