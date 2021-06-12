using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionClear : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameEvents.FireSelectionCleared(this, 0);
    }
}
