using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Projectails : MonoBehaviour
{
    [SerializeField] private float _projectailsRange = 3;
    [SerializeField] private HeroBase _heroBase;

    [SerializeField] private int _damage = 5;
    private void OnEnable()
    {
        var randomPos = GetRandomPosition();
        gameObject.transform.DOJump(GetRandomPosition(), 0.5f, 2, UnityEngine.Random.Range(2, 5)).OnComplete(() => gameObject.SetActive(false));
    }
    private Vector3 GetRandomPosition()
    {
        return new Vector3(_heroBase.transform.position.x + UnityEngine.Random.Range(0, _projectailsRange),
            _heroBase.transform.position.y + UnityEngine.Random.Range(0, _projectailsRange));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            _heroBase._currentHealth -= _damage;
        }
    }
}
