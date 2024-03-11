using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Weapon _currentItem;

    private void PickUp()
    {
        InventoryHandler.Instance.AddWeapon(_currentItem);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
}
