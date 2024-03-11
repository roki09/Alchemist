using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponImageInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private SpriteRenderCollection spriteCollection;
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private HeroBase heroBase;

    public Weapon currentItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        statsText.text = currentItem.ShowStats();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        statsText.text = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (Transform child in heroBase.gameObject.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
        var hand = Instantiate(spriteCollection.weaponsPrefab[currentItem._index], heroBase.transform);
        var item = hand.GetComponent<HandsBase>();
        item.equippedItem = currentItem;
    }
}
