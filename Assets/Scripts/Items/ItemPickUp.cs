using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Item _currentItem;


    public Item GetItem()
    {
        return _currentItem;
    }
    private void PickUp()
    {
        InventoryHandler.Instance.AddItem(_currentItem);
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
