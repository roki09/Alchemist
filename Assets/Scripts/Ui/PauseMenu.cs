using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    public InterstitialAds ad;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_canvas.isActiveAndEnabled)
            {
                PauseOn();
                ad.ShowAd();
            }
            else
                PauseOff();
        }
    }

    public void PauseOn()
    {
        _canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseOff()
    {
        _canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
