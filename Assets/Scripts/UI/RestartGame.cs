using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour, IPointerClickHandler
{
    public string startingScene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(startingScene);
    }
}
