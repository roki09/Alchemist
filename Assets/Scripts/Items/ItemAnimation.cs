using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] Collider2D currentCollider;


    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float timer = 1;
    [SerializeField] private float resetTimer = 1;
    [SerializeField] private float switschAnimation = 1;

    private void Awake()
    {
        currentCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        DropAnimation();
    }

    private void Update()
    {
        UpDowpAnimation();
    }



    private void UpDowpAnimation()
    {
        switch (switschAnimation)
        {
            case 1:
                UpAnima();
                break;
            case 2:
                DownAnima();
                break;
        }
    }


    private void UpAnima()
    {
        if (timer > 0)
        {
            var step = speed * Time.deltaTime;
            transform.Translate(Vector3.up * step);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = resetTimer;
            switschAnimation = 2;
        }
    }

    private void DownAnima()
    {
        if (timer > 0)
        {
            var step = speed * Time.deltaTime;
            transform.Translate(Vector3.down * step);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = resetTimer;
            switschAnimation = 1;
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x + UnityEngine.Random.Range(0, 2f),
            transform.position.y + UnityEngine.Random.Range(0, 2f));
    }
    private void DropAnimation()
    {
        transform.DOJump(GetRandomPosition(), 0.5f, 3, 3)
            .SetLink(gameObject)
            .OnKill(() => EnableCollider());
    }

    private void EnableCollider()
    {
        currentCollider.enabled = true;
    }

}
