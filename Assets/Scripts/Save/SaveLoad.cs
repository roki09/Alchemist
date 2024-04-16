using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private MainHero _mainHero;
    [SerializeField] private InventoryHandler _inventory;

    private const string saveKey = "mainSave";

    public void AutoSave()
    {
        SaveManager.Save(saveKey, GetSaveSnapShotAutoSave());
    }

    public void LoadAutoSave()
    {
        var date = SaveManager.Load<SaveDate.PlayerPrefsData>(saveKey);
        _inventory.items = date.Items;
        foreach (var item in date.Weapons)
        {
            _inventory.items.Add(item);
        }
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapShot());
    }

    public void Load()
    {
        var date = SaveManager.Load<SaveDate.PlayerPrefsData>(saveKey);

        _mainHero.transform.position = date.HeroPosition;
        _inventory.items = date.Items;
        foreach (var item in date.Weapons)
        {
            _inventory.items.Add(item);
        }
    }

    private SaveDate.PlayerPrefsData GetSaveSnapShotAutoSave()
    {
        var data = new SaveDate.PlayerPrefsData()
        {
            Items = ItemsList(),
            Weapons = WeaponsList(),
        };
        return data;
    }

    private SaveDate.PlayerPrefsData GetSaveSnapShot()
    {
        var data = new SaveDate.PlayerPrefsData()
        {

            HeroPosition = _mainHero.transform.position,
            SceneIndex = 1,
            Items = ItemsList(),
            Weapons = WeaponsList(),
        };

        return data;
    }

    public List<Weapon> WeaponsList()
    {
        var list = new List<Weapon>();
        foreach (var item in _inventory.items)
        {
            if (item is Weapon)
            {
                list.Add((Weapon)item);
            }
        }
        return list;
    }

    public List<Item> ItemsList()
    {
        var list = new List<Item>();
        foreach (var item in _inventory.items)
        {
            if (item is Weapon)
                continue;
            else
                list.Add(item);
        }
        return list;
    }

}
