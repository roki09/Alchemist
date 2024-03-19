using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class ChestLogic : MonoBehaviour, IInteractable
{
    public List<Item> _items = new List<Item>();
    [SerializeField] private SpriteRenderCollection _spriteCollection;

    [SerializeField] private Transform _scrollView;
    [SerializeField] private Transform _itemContent;
    [SerializeField] private Image _imageForPickUp;

    private bool _isOpen = false;


    private void Start()
    {
        CreateItems();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_isOpen == true)
            {
                Close();
                _isOpen = false;
            }
        }
    }

    private void CreateItems()
    {
        int countOfItem = Random.Range(1, 4);

        for (int i = 0; i < countOfItem; i++)
        {
            int ItemOrWeapon = Random.Range(0, 2);
            if (ItemOrWeapon == 0)
            {
                int index = Random.Range(0, 18);
                _items.Add(new Item(index, LibraryItemsNaims.ItemsName[index], LibraryMethods.GetRendomRaryti(), Random.Range(50, 300)));
            }
            else if (ItemOrWeapon == 1)
            {
                int index = Random.Range(0, 4);
                _items.Add(new Weapon(index, LibraryItemsNaims.WeaponsName[index], LibraryMethods.GetRendomRaryti(), Random.Range(20, 100), Random.Range(5, 12)));
            }
        }
    }

    private void SetupCardForCheast()
    {
        foreach (Transform item in _itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in _items)
        {
            Image obj = Instantiate(_imageForPickUp, _itemContent);

            var currentItem = obj.GetComponent<ItemImageForChest>();
            currentItem._currentItem = item;

            var rarytiSprite = obj.GetComponent<Image>();
            var itemIcon = obj.transform.Find("ImageOfItem").GetComponent<Image>();

            rarytiSprite.sprite = _spriteCollection.spritesOfRarytiBackground[item._rarity];

            if (item is Weapon)
                itemIcon.sprite = _spriteCollection.spritesOfWeaponForInventory[item._index];
            else
                itemIcon.sprite = _spriteCollection.sprites[item._index];
        }
    }

    public void Interact(HeroBase hero)
    {
        if (_items != null)
        {
            Open();
        }
    }

    private void Open()
    {
        _isOpen = true;
        _scrollView.gameObject.SetActive(true);
        SetupCardForCheast();
    }
    private void Close()
    {
        _scrollView.gameObject.SetActive(false);
    }
}
