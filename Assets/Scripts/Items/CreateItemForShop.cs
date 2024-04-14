using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CreateItemForShop : MonoBehaviour
{
    [SerializeField] private SpriteRenderCollection spriteCollection;
    [SerializeField] private int _countOfItem;
    [SerializeField] private Image _imageReference;
    [SerializeField] List<Item> itemsInShop = new List<Item>();

    [SerializeField] Transform _shopScroll;


    private void Start()
    {
        SetupCard();
    }

    private void SetupCard()
    {
        CreateItem();
        CreateImageForItem();
    }


    private void CreateItem()
    {
        for (int i = 0; i < _countOfItem; i++)
        {
            int index = UnityEngine.Random.Range(0, 6);

            Item currentItem = new Item(
                index,
                LibraryItemsNaims.ItemsName[index],
                UnityEngine.Random.Range(0, 4),
                UnityEngine.Random.Range(100, 300));

            itemsInShop.Add(currentItem);
        }
    }

    private void CreateImageForItem()
    {
        foreach (Item item in itemsInShop)
        {
            Image image = Instantiate(_imageReference, _shopScroll);
            var itemInImage = image.GetComponent<BuyLogic>();
            var rarytiItem = image.GetComponent<Image>();
            var spriteItem = image.transform.Find("ImageOfItem").GetComponent<Image>();

            itemInImage.currentItem = item; 
            rarytiItem.sprite = spriteCollection.spritesOfRarytiBackground[item.rarity];
            spriteItem.sprite = spriteCollection.sprites[item.index];

        }
    }

}
