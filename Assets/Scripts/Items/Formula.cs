using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Formula : MonoBehaviour
{
    [SerializeField] SpriteRenderCollection spriteCollection;
    [SerializeField] private Image[] images;
    [SerializeField] private Image craftedItemReferense;

    public string formulaName;
    private Item craftedItem;

    public Item
        ingredient1,
        ingredient2,
        ingredient3;

    public bool
        itemExist1,
        itemExist2,
        itemExist3;



    private List<Item> FindIngredient()
    {
        Item[] itemsArray = new Item[3] { ingredient1, ingredient2, ingredient3 };
        bool[] boolsArray = new bool[3] { itemExist1, itemExist2, itemExist3 };
        List<Item> listOfItem = new List<Item>();

        var itemsList = InventoryHandler.Instance.items;

        for (int i = 0; i < itemsArray.Length; i++)
        {
            foreach (var item in itemsList)
            {
                if (item.name == itemsArray[i].name)
                {
                    listOfItem.Add(item);
                    boolsArray[i] = true;
                }
            }
        }
        return listOfItem;
    }

    public void CraftItem()
    {
        var listOfItem = FindIngredient();
        var weHaveAllIngredients = CheckBool();
        if (weHaveAllIngredients == true)
        {
            InventoryHandler.Instance.AddItem(craftedItem);
            ChangeInventory(listOfItem);
        }
            
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


    private bool CheckBool()
    {
        bool[] boolsArray = new bool[3] { itemExist1, itemExist2, itemExist3 };
        foreach (var item in boolsArray)
        {
            if(item == false)
                return false;
        }
        return true;
    }

    private void ChangeInventory(List<Item> listOfItem)
    {
        foreach (var item in listOfItem)
        {
            InventoryHandler.Instance.RemoveItem(item);
        }
    }


}

