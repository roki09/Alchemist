using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    //[SerializeField] private Visual _heroDetector;
    [SerializeField] private SlimeBase _slime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _slime._heroIsNear = true;
            Debug.Log("hero");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _slime._heroIsNear = false;
            Debug.Log("hero");
        }
    }
}
