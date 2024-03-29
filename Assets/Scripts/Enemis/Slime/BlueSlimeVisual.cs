using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeVisual : MonoBehaviour
{
    [SerializeField] private BlueSlime _slime;

    private void Awake()
    {
        _slime = GetComponentInParent<BlueSlime>();
    }
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
