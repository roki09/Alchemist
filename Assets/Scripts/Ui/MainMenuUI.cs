using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    //0 - MainMenu, 1 - LoadGame, 2 - Options
    [SerializeField] private Canvas[] _canvasGroup;

    public void ExitToMain()
    {
        
        foreach (var item in _canvasGroup)
        {
            if (item.isActiveAndEnabled)
                item.gameObject.SetActive(false);
        }
        _canvasGroup[0].gameObject.SetActive(true);
    }

    public void OpenLoadGame()
    {
        _canvasGroup[0].gameObject.SetActive(false);
        _canvasGroup[1].gameObject.SetActive(true);
    }

    public void OpenOptions() 
    {
        _canvasGroup[0].gameObject.SetActive(false);
        _canvasGroup[2].gameObject.SetActive(true);
    }
}
