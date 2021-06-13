using UnityEngine;

public class GrandmaInventory : MonoBehaviour
{
    public int startingInventory;
    public int currentInventory;

    void Start()
    {
        currentInventory = startingInventory;
        GameEvents.GrandmaPlacedListeners += ReduceInventory;
        GameEvents.WaveStartedListeners += IncreaseInventory;
    }

    private void ReduceInventory(object sender, string e)
    {
        if (currentInventory > 0)
            currentInventory--;
    }

    public void IncreaseInventory(object sender, string e)
    {
        currentInventory++;
    }
}
