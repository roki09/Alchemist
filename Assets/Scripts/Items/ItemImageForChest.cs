using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemImageForChest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _statsText;
    [SerializeField] private HeroBase _hero;

    public Item _currentItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_statsText.gameObject != null)
            _statsText.text = _currentItem.ShowStats();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _statsText.text = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryHandler.Instance.AddItem(_currentItem);
        foreach (var item in _hero.chestLogic._items)
        {
            if (_currentItem == item)
            {
                _hero.chestLogic._items.Remove(item);
                break;
            }
        }
        Destroy(gameObject);
    }
}
