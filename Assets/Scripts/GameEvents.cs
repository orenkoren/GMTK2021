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

    public static EventHandler<string> WaveStartedListeners;
    public static void FireWaveStarted(object sender, string placeholder) =>
                                        WaveStartedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> WaveFinishedListeners;
    public static void FireWaveFinished(object sender, string placeholder) =>
                                        WaveFinishedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> WavePhasedListeners;
    public static void FireWavePhased(object sender, string placeholder) =>
                                        WavePhasedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> GrandmaPlacedListeners;
    public static void FireGrandmaPlaced(object sender, string placeholder) =>
                                        GrandmaPlacedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> LevelFinishedListeners;
    public static void FireLevelFinished(object sender, string placeholder) =>
                                        LevelFinishedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> LevelFailedListeners;
    public static void FireLevelFailed(object sender, string placeholder) =>
                                        LevelFailedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> CatSavedListeners;
    public static void FireCatSaved(object sender, string placeholder) =>
                                        CatSavedListeners?.Invoke(sender, placeholder);

    public static EventHandler<string> MergeListeners;
    public static void FireMerge(object sender, string placeholder) =>
                                        MergeListeners?.Invoke(sender, placeholder);

    public static GameObject FirstSelectedObject;
    public static GameObject SecondSelectedObject;

}
