using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsForDrop;

    public void DropItems()
    {
        foreach (var item in itemsForDrop)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
