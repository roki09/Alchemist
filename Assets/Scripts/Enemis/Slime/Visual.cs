using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    private Enemis _enemis;

    private void Awake()
    {
        _enemis = GetComponentInParent<Enemis>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemis.heroIsNear = true;
            Debug.Log("hero");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemis.heroIsNear = false;
            Debug.Log("hero");
        }
    }
}
