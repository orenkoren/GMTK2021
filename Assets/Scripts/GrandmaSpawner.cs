using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GrandmaSpawner : MonoBehaviour
{
    [SerializeField] private float grandmaSpacing = 3;
    [SerializeField] private GameObject ground;
    [SerializeField] private LayerMask grandmaLayer;
    [SerializeField] private GameObject grandmaIndicator;
    [SerializeField] private GameObject failIndicator;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GrandmaInventory inventory;

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
                if (inventory.currentInventory > 0)
                    instantiateIndicator();
                else
                    InstantiateFailure();
            }
        }
    }

    private bool repositionIndicator()
    {
        PointerEventData ped = new PointerEventData(eventSystem);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(ped, results);
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

    private void InstantiateFailure()
    {
        Vector3 mousePosition = GetMousePosition();
            indicatorInstance = Instantiate(failIndicator, mousePosition, Quaternion.identity);
            graphicRaycaster = indicatorInstance.GetComponent<GraphicRaycaster>();
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, 999f))
        {
            if (raycastHit.collider.gameObject.name == ground.name)
                return raycastHit.point;
            else
                return Vector3.zero;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
