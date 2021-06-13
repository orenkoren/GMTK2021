using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour, IPointerClickHandler
{
    public string SceneName;

    private void Start()
    {
        GameEvents.LevelFinishedListeners += EnableButton;
        gameObject.SetActive(false);

    }

    private void EnableButton(object sender, string e)
    {
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneName);
    }

    private void OnDestroy()
    {
        GameEvents.LevelFinishedListeners -= EnableButton;
    }

}
