using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrandmaIndicator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject grandma;
    void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Instantiate(grandma, transform.position, grandma.transform.rotation);
            GameEvents.FireGrandmaPlaced(this, "");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
