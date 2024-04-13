using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsLogic : MonoBehaviour
{
    public Canvas previous—anvas;
    public Canvas currentCanvas;

    public void SwichCanvas()
    {
        previous—anvas.gameObject.SetActive(false);
        currentCanvas.gameObject.SetActive(true);
        previous—anvas = currentCanvas;
    }

    public void DisableCurtains()
    {
        gameObject.SetActive(false);
    }
}
