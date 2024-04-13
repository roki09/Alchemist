using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private CurtainsLogic curtains;


    public void EnableCurtains(Canvas canvas)
    {
        curtains.currentCanvas = canvas;
        curtains.gameObject.SetActive(true);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
