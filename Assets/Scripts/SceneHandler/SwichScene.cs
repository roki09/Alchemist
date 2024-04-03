using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichScene : MonoBehaviour
{
    [SerializeField] private int scene;

    public void SwichToScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
}
