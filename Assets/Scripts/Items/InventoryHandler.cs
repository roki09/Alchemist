using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    [SerializeField] SpriteRenderCollection spriteCollection;
    [SerializeField] public List<Item> items = new List<Item>();
    //[SerializeField] List<Weapon> weapons = new List<Weapon>();

    public Transform ItemContent;
    public Image InventoryItem;
    public Image WeaponItem;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    //public void AddWeapon(Weapon weapon)
    //{
    //    weapons.Add(weapon);
    //}

    //public void RemoveWeapon(Weapon weapon)
    //{
    //    weapons.Remove(weapon);
    //}

    public void RemoveItem(Item item)
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
            if (item is Weapon)
            {
                Image obj = Instantiate(WeaponItem, ItemContent);

                var currentItem = obj.GetComponent<WeaponImageInteract>();
                currentItem.currentItem = (Weapon)item;

                var rarytiSprite = obj.GetComponent<Image>();
                var itemIcon = obj.transform.Find("ImageOfItem").GetComponent<Image>();

                rarytiSprite.sprite = spriteCollection.spritesOfRarytiBackground[item._rarity];
                itemIcon.sprite = spriteCollection.spritesOfWeaponForInventory[item._index];
            }
            else
            {

                Image obj = Instantiate(InventoryItem, ItemContent);

                var currentItem = obj.GetComponent<ItemShowStats>();
                currentItem.currentItem = item;

                var rarytiSprite = obj.GetComponent<Image>();
                var itemIcon = obj.transform.Find("ImageOfItem").GetComponent<Image>();

                rarytiSprite.sprite = spriteCollection.spritesOfRarytiBackground[item._rarity];
                itemIcon.sprite = spriteCollection.sprites[item._index];
            }

        }

        //foreach (var item in weapons)
        //{
        //    Image obj = Instantiate(WeaponItem, ItemContent);

        //    var currentItem = obj.GetComponent<WeaponImageInteract>();
        //    currentItem.currentItem = item;

        //    var rarytiSprite = obj.GetComponent<Image>();
        //    var itemIcon = obj.transform.Find("ImageOfItem").GetComponent<Image>();

        //    rarytiSprite.sprite = spriteCollection.spritesOfRarytiBackground[item._rarity];
        //    itemIcon.sprite = spriteCollection.spritesOfWeaponForInventory[item._index];
        //}
    }
}
