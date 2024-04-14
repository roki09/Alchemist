using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[Serializable]
public class Item
{

    public int index;
    public string name;
    public int rarity;
    public int cost;

    public Item(int index, string name, int raryti, int cost)
    {
        this.index = index;
        this.name = LibraryItemsNaims.ItemsName[index];
        rarity = raryti;
        if (raryti == 0)
            this.cost = cost * 1;
        else
            this.cost = cost * raryti;
    }


    public virtual string ShowStats()
    {
        return $"Name: {LibraryItemsNaims.ItemsName[index]}\n" +
            $"Rarity: {LibraryItemsNaims.RarytiName[rarity]}\n" +
            $"Cost: {cost}";
    }

}
