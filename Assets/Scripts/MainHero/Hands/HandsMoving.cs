using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class HandsMoving : MonoBehaviour
{
    private float MaxRadius = 2f;
    [SerializeField] Camera camera;
    [SerializeField] Rigidbody2D heroRB;
    [SerializeField] HeroBase heroBase;

    // Update is called once per frame

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newPos = camera.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(heroRB.transform.position, newPos) < MaxRadius)
        {
            transform.position = newPos;
        }
        else
        {
            var direction = (newPos - heroRB.transform.position).normalized * MaxRadius;
            transform.position = heroRB.transform.position + direction;
        }

        //if (Vector2.Distance(newPos, heroRB.position) > radius)
        //    handsRB.position = heroRB.position + (newPos - heroRB.position).normalized * radius;
        //else
        //    handsRB.position = newPos;
    }
}
