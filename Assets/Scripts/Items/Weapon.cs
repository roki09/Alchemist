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

        base.index = index;
        base.name = LibraryItemsNaims.WeaponsName[index];
        rarity = raryti;
        if (raryti == 0)
            base.cost = cost * 1;
        else
            base.cost = cost * raryti;
    }

    public override string ShowStats()
    {
        return $"Name: {LibraryItemsNaims.WeaponsName[index]}\n" +
            $"Rarity: {LibraryItemsNaims.RarytiName[rarity]}\n" +
            $"Cost: {cost}\n" +
            $"Damage: {_damage}";
    }
}
