using UnityEngine;
using UnityEngine.UI;

public class GrandmaDisplay : MonoBehaviour
{
    public Text grandmaAmountText;
    public GrandmaInventory inventory;

    private void Update()
    {
        grandmaAmountText.text = inventory.currentInventory.ToString();
    }
}
