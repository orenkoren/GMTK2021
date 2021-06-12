using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public LayerMask selectableLayer;

    void Start()
    {
        GameEvents.ObjectSelectedListeners += HandleSelection;
        GameEvents.SelectionClearedListeners += ClearSelections;
    }

    private void ClearSelections(object sender, int e)
    {
        GameEvents.FirstSelectedObject = null;
        GameEvents.SecondSelectedObject = null;
    }

    private void HandleSelection(object sender, int e)
    {
        if (GameEvents.FirstSelectedObject && !GameEvents.SecondSelectedObject)
        {
            if (GameEvents.FirstSelectedObject.GetInstanceID() != ((GameObject)sender).GetInstanceID())
            {
                GameEvents.SecondSelectedObject = (GameObject)sender;
            }
            ((GameObject)sender).GetComponent<Selectable>().HandleSelection(true);
        }
        else if (!GameEvents.FirstSelectedObject)
        {
            GameEvents.FirstSelectedObject = (GameObject)sender;
            ((GameObject)sender).GetComponent<Selectable>().HandleSelection(true);
        }
    }

    private void OnDestroy()
    {
        GameEvents.ObjectSelectedListeners -= HandleSelection;
        GameEvents.SelectionClearedListeners -= ClearSelections;
    }
}
