using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBase : MonoBehaviour
{
    public ChestLogic ChestLogic;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] public int _currentHealth = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheast"))
        {
            Debug.Log("Enter Chest");
            ChestLogic = collision.gameObject.GetComponent<ChestLogic>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheast"))
        {
            Debug.Log("Exit Chest");
            ChestLogic = null;
        }
    }
}
