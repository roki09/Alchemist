using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ItemAnimation), typeof(ItemPickUp), typeof(SpriteRenderer)),]

public class ItemInGround : MonoBehaviour
{
    [Serialize] private Item _currentItem;

    private ItemPickUp _pickUp;
    private SpriteRenderer _sprite;
    private SpriteRenderCollection _sripteCollection;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _pickUp = GetComponent<ItemPickUp>();
    }

    private void Start()
    {
        var item = _pickUp.GetItem();
        item = _currentItem;
        _sprite.sprite = _sripteCollection.sprites[_currentItem.index];
    }

}
