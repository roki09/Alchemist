using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon : Item
{
    public int _damage;

    public Weapon(int index, string name, int raryti, int cost, int damage) : base(index, name, raryti, cost)
    {
        if (raryti != 0)
            _damage = damage * (1 + (raryti % 10));
        else
            _damage = damage;

        _index = index;
        _name = LibraryItemsNaims.WeaponsName[index];
        _rarity = raryti;
        if (raryti == 0)
            _cost = cost * 1;
        else
            _cost = cost * raryti;
    }

    public override string ShowStats()
    {
        return $"Name: {LibraryItemsNaims.WeaponsName[_index]}\n" +
            $"Rarity: {LibraryItemsNaims.RarytiName[_rarity]}\n" +
            $"Cost: {_cost}\n" +
            $"Damage: {_damage}";
    }
}
