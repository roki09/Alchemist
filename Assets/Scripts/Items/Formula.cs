using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formula : MonoBehaviour
{
    [SerializeField] SpriteRenderCollection spriteCollection;
    [SerializeField] private Image[] images = new Image[3];

    [SerializeField] private Image craftedItemReferense;

    public string formulaName;
    public Item craftedItem;

    public Item
        ingredient1,
        ingredient2,
        ingredient3;

    public bool
        itemExist;



    private List<Item> FindIngredient()
    {
        Item[] itemsArray = new Item[3] { ingredient1, ingredient2, ingredient3 };
        List<Item> listOfItem = new List<Item>();

        var itemsList = InventoryHandler.Instance.items;

        for (int i = 0; i < itemsArray.Length; i++)
        {
            foreach (var item in itemsList)
            {
                if (item.name == itemsArray[i].name)
                {
                    listOfItem.Add(item);
                    InventoryHandler.Instance.items.Remove(item);
                    break;
                }
            }
        }
        if (listOfItem.Count == 3)
            itemExist = true;
        return listOfItem;
    }

    public void CraftItem()
    {
        var listOfItem = FindIngredient();
        if (itemExist == true)
            InventoryHandler.Instance.AddItem(craftedItem);
        else
            InventoryHandler.Instance.AddItem(new Item(4, "CursedPot", 0, 1));
        itemExist = false;
    }

    public void ChangeImage()
    {
        Item[] itemsArray = new Item[3] { ingredient1, ingredient2, ingredient3 };
        craftedItemReferense.sprite = spriteCollection.sprites[craftedItem.index];
        for (int i = 0; i < 3; i++)
        {
            images[i].sprite = spriteCollection.sprites[itemsArray[i].index];
        }
    }


    private void ChangeInventory(List<Item> listOfItem)
    {
        foreach (var item in listOfItem)
        {
            InventoryHandler.Instance.RemoveItem(item);
        }
    }


}

