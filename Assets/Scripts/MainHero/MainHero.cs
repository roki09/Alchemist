using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHero : MonoBehaviour
{
    public ChestLogic chestLogic;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] public int _currentHealth = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactble))
        {
            chestLogic = interactble as ChestLogic;
            interactble.Interact(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheast"))
        {
            Debug.Log("Exit Chest");
            chestLogic = null;
        }
    }
}
