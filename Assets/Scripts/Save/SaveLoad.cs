using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private MainHero _mainHero;
    [SerializeField] private InventoryHandler _inventory;

    private const string saveKey = "mainSave";


    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapShot());
    }

    public void Load()
    { 
        var date = SaveManager.Load<SaveDate.PlayerPrefsData>(saveKey);

        _mainHero.transform.position = date.HeroPosition;
        _inventory.items = date.Items;
    }

    private SaveDate.PlayerPrefsData GetSaveSnapShot()
    {
        var data = new SaveDate.PlayerPrefsData()
        {
            HeroPosition = _mainHero.transform.position,
            Items = _inventory.items,
            // I need get scene index
            SceneIndex = 1,
        };

        return data;
    }   
}
