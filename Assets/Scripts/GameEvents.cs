using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event EventHandler<int> ObjectSelectedListeners;

    public static void FireObjectSelected(object sender, int id) =>
                                            ObjectSelectedListeners?.Invoke(sender, id);
    public static event EventHandler<int> ObjectRightClickListeners;

    public static void FireObjectRightClick(object sender, int id) =>
                                            ObjectRightClickListeners?.Invoke(sender, id);

    public static event EventHandler<int> SelectionClearedListeners;

    public static void FireSelectionCleared(object sender, int id) =>
                                            SelectionClearedListeners?.Invoke(sender, id);

    public static GameObject FirstSelectedObject;
    public static GameObject SecondSelectedObject;

}
