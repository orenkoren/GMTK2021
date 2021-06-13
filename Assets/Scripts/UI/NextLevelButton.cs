using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour, IPointerClickHandler
{
    public string SceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneName);
    }

}
