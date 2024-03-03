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
    private void Start()
    {
        Debug.Log("start");

    }
    public int _index;
    public string _name;
    public int _rarity;
    public int _cost;

    public Item(int index, string name, int raryti, int cost)
    {
        _index = index;
        _name = name;
        _rarity = raryti;
        if (raryti == 0)
            _cost = cost * 1;
        else
            _cost = cost * raryti;
    }


    public virtual string ShowStats()
    {
        return $"Name: {_name}\n" +
            $"Rarity: {_rarity}\n" +
            $"Cost: {_cost}";
    }

}
