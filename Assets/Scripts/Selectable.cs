using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool isSelected;

    private void Start()
    {
        GameEvents.SelectionClearedListeners += ClearSelection;
    }

    private void OnMouseDown()
    {
        GameEvents.FireObjectSelected(gameObject, gameObject.GetInstanceID());
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
            GameEvents.FireObjectRightClick(gameObject, gameObject.GetInstanceID());
    }

    public void HandleSelection(bool isSelected)
    {
        this.isSelected = isSelected;
        var outline = GetComponent<Outline>();
        if (outline)
            GetComponent<Outline>().enabled = isSelected;
    }

    private void ClearSelection(object sender, int e)
    {
        HandleSelection(false);
    }

    private void OnDestroy()
    {
        GameEvents.SelectionClearedListeners -= ClearSelection;
    }
}
