using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_canvas.isActiveAndEnabled)
                PauseOn();
            else
                PauseOff();
        }
    }

    private void PauseOn()
    {
        _canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void PauseOff()
    {
        _canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
