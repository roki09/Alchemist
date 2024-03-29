using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemis : MonoBehaviour
{
    private SpriteRenderer sprite;
    private ItemDrop drop;
    public bool takeDamage = false;

    [SerializeField] private int _maxHealth;
    [SerializeField] public int _currentHealth;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        drop = GetComponent<ItemDrop>();
    }


    public void EnemisDead()
    {
        if (_currentHealth <= 0)
        {
            sprite.DOFade(0, 1).
                SetLink(gameObject).
                OnComplete(() => AfterDeadAnimation());
        }
    }

    private void AfterDeadAnimation()
    {
        drop.DropItems();
        Destroy(gameObject);
    }
}
