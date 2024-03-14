using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class HandsMoving : MonoBehaviour
{
    private float MaxRadius = 2f;
    [SerializeField] HeroBase heroBase;
    [SerializeField] Rigidbody2D heroRB;

    private Camera cam;
    private HeroDirectionReader directionForRoatete;
    private Rigidbody2D weaponRB;


    private void Awake()
    {
        cam = FindAnyObjectByType<Camera>();
        weaponRB = GetComponent<Rigidbody2D>();
        heroBase = GetComponentInParent<HeroBase>();
        heroRB = heroBase.GetComponent<Rigidbody2D>();
        directionForRoatete = GetComponentInParent<HeroDirectionReader>();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(heroRB.transform.position, newPos) < MaxRadius)
        {
            transform.position = newPos;
        }
        else
        {
            var direction = (newPos - heroRB.transform.position).normalized * MaxRadius;
            transform.position = heroRB.transform.position + direction;

            transform.rotation = Quaternion.LookRotation(direction, directionForRoatete.direction);
        }
    }

}
