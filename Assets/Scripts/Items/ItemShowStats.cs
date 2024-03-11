using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemShowStats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI statsText;
    public Item currentItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        statsText.text = currentItem.ShowStats();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        statsText.text = null;
    }
}
