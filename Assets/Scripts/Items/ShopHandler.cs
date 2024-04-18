using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderCollection _spriteRender;
    [SerializeField] private Transform _shopContent, _inventoryContent;
    [SerializeField] private Button _buttonForSell, _buttonForBuy,
        _buttonForBuyFormula, _buttonForSellFormula;

    [SerializeField] private List<Item> _shopContainer;
    [SerializeField] private List<Weapon> _weaponContainer;
    [SerializeField] private List<Formula> _formulaContainer;

    public void SetupAllItem()
    {
        SetupCardForShop(_shopContent, _buttonForBuy, _shopContainer);
        SetupCardForShop(_inventoryContent, _buttonForSell, InventoryHandler.Instance.items);
    }
    
    public void SetupAllFormula()
    {
        SetupCardForShop(_shopContent, _buttonForBuyFormula, _formulaContainer);
        SetupCardForShop(_inventoryContent, _buttonForSellFormula, InventoryHandler.Instance.formulas);
    }


    public void SetupCardForShop(Transform content, Button buttonsExample, List<Item> items)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            var button = Instantiate(buttonsExample, content);
            var currentItem = button.GetComponent<ItemShowStats>();
            currentItem.currentItem = item;

            var buttonsText = button.GetComponentInChildren<TextMeshProUGUI>();
            //var imageOfItem = button.GetComponentInChildren<Image>();
            buttonsText.text = item.name;

            //if (item is Weapon)
            //    imageOfItem.sprite = _spriteRender.spritesOfWeaponForInventory[item.index];
            //else
            //    imageOfItem.sprite = _spriteRender.sprites[item.index];
            LibraryMethods.GetColor(buttonsText, item);
        }
    }

    public void SetupCardForShop(Transform content, Button buttonsExample, List<Formula> items)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            var button = Instantiate(_buttonForBuy, content);
            var currentFormula = button.GetComponent<Formula>();

            currentFormula = item;

            var buttonsText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonsText.text = item.formulaName;
            LibraryMethods.GetColor(buttonsText, item.craftedItem);
        }
    }

}
