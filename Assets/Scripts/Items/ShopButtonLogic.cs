using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonLogic : MonoBehaviour
{
    [SerializeField] private SpriteRenderCollection _renderCollection;
    [SerializeField] private CoinsScore coins;

    //private void OnEnable()
    //{
    //    ChangeImage();
    //}
    public void BuyItem()
    {
        var item = gameObject.GetComponent<ItemShowStats>();
        if (PlayersMoney.moneyCount > item.currentItem.cost)
        {
            PlayersMoney.moneyCount -= item.currentItem.cost;
            InventoryHandler.Instance.AddItem(item.currentItem);
            Destroy(gameObject);
            coins.SetScore();
        }
    }

    public void SellItem()
    {
        var item = gameObject.GetComponent<ItemShowStats>();
        PlayersMoney.moneyCount += item.currentItem.cost;
        InventoryHandler.Instance.RemoveItem(item.currentItem);
        Destroy(gameObject);
        coins.SetScore();
    }

    public void BuyFormula(Formula formula)
    {
        if (PlayersMoney.moneyCount > formula.cost)
        {
            PlayersMoney.moneyCount -= formula.cost;
            InventoryHandler.Instance.AddFormula(formula);
            Destroy(gameObject);
            coins.SetScore();
        }
    }

    //private void ChangeImage()
    //{
    //    var item = gameObject.GetComponent<ItemShowStats>();
    //    var image = gameObject.GetComponentInChildren<Image>();
    //    if (item != null)
    //    {
    //        if (item.currentItem is Weapon)
    //            image.sprite = _renderCollection.spritesOfWeaponForInventory[item.currentItem.index];
    //        else
    //            image.sprite = _renderCollection.sprites[item.currentItem.index];
    //    }
    //}
}
