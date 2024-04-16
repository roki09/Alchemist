using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetupButtonsForCraft : MonoBehaviour
{
    [SerializeField] private Transform _formulaContent;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        SetupButtons();
    }
    private void SetupButtons()
    {
        foreach (Transform item in _formulaContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var formula in InventoryHandler.Instance.formulas)
        {
            var button = Instantiate(_button, _formulaContent);

            var buttonsText = GetComponentInChildren<TextMeshProUGUI>();
            buttonsText.text = formula.name;
            GetColor(buttonsText, formula.craftedItem);
        }
    }

    private void GetColor(TextMeshProUGUI text, Item item)
    {
        switch (item.rarity)
        {
            case 0:
                break;

            case 1:
                text.color = Color.green;
                break;

            case 2:
                text.color = Color.blue;
                break;

            case 3:
                text.color = Color.yellow;
                break;

        }
    }
}
