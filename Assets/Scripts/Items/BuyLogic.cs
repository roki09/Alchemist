using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyLogic : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _state;
    [SerializeField] private CoinsScore moneyScore;
    public Item currentItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        BoyItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _state.text = currentItem.ShowStats();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _state.text = null;
    }

    private void BoyItem()
    {
        if (currentItem._cost < PlayersMoney.moneyCount)
        {
            PlayersMoney.moneyCount -= currentItem._cost;
            InventoryHandler.Instance.Add(currentItem);
            Destroy(gameObject);
            moneyScore.SetScore();
        }
    }
}
