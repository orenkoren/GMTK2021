using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GrandmaSpawner : MonoBehaviour
{
    [SerializeField] private float grandmaSpacing = 3;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask grandmaLayer;
    [SerializeField] private GameObject grandmaIndicator;
    [SerializeField] private EventSystem eventSystem;

    private GameObject indicatorInstance;
    private GraphicRaycaster graphicRaycaster;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.paused && Input.GetMouseButtonDown(0))
        {
            if (indicatorInstance == null || repositionIndicator())
            {
                instantiateIndicator();
            }
        }
    }

    private bool repositionIndicator()
    {
        PointerEventData ped = new PointerEventData(eventSystem);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(ped, results);
        print(results.ToArray());
        if (results.ToArray().Length == 0)
        {
            Destroy(indicatorInstance);
            return true;
        }
        return false;
    }

    private void instantiateIndicator()
    {
        Vector3 mousePosition = GetMousePosition();
        RaycastHit[] hits = Physics.SphereCastAll(mousePosition, grandmaSpacing, transform.up, 0.1f, grandmaLayer, QueryTriggerInteraction.UseGlobal);

        if (mousePosition != Vector3.zero && hits.Length == 0)
        {
            indicatorInstance = Instantiate(grandmaIndicator, mousePosition, Quaternion.identity);
            graphicRaycaster = indicatorInstance.GetComponent<GraphicRaycaster>();
        }
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, 999f, groundLayer))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
