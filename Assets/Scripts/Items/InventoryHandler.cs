using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    [SerializeField] SpriteRenderCollection spriteCollection;
    [SerializeField] List<Item> items = new List<Item>();

    public Transform ItemContent;
    public Image InventoryItem;

    private void Awake()
    {
            Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void SetupCard()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            Image obj = Instantiate(InventoryItem, ItemContent);
            var rarytiSprite = obj.GetComponent<Image>();
            var itemIcon = obj.transform.Find("ImageOfItem").GetComponent<Image>();

            rarytiSprite.sprite = spriteCollection.spritesOfRarytiBackground[item._rarity];
            itemIcon.sprite = spriteCollection.spritesOfBigPoution[item._index];

        }
    }
}
