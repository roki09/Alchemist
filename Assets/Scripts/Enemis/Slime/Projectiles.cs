using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float _projectailsRange = 3;
    [SerializeField] private MainHero _heroBase;
    [SerializeField] private int _damage = 5;
    [SerializeField] private TextMeshProUGUI _mainHeroHp;

    public bool flies = false;

    public void Throw()
    {
        flies = true;
        var randomPos = GetRandomPosition();
        gameObject.transform.DOJump(GetRandomPosition(), 0.5f, 3,3)
            .SetLink(gameObject)
            .OnComplete(() => Inactiv());
    }
    private Vector3 GetRandomPosition()
    {
        return new Vector3(_heroBase.transform.position.x + UnityEngine.Random.Range(0, _projectailsRange),
            _heroBase.transform.position.y + UnityEngine.Random.Range(0, _projectailsRange));
    }

    private void Inactiv() 
    { 
        flies = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            LibraryMethods.MainHeroGetDamage(_damage, _heroBase, _mainHeroHp);
        }
    }
}
