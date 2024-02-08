using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDirectionReader : MonoBehaviour
{
    [SerializeField] private float horizontalDirection;
    [SerializeField] private float verticalDirection;
    [SerializeField] private float speed = 10;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        SetDirection();
        Move();
    }

    private void FixedUpdate()
    {
        Flip();
        AnimationControl();
    }

    public void SetDirection()
    {
       horizontalDirection = Input.GetAxis("Horizontal");
       verticalDirection = Input.GetAxis("Vertical");
    }

    public void Move()
    {
        if(horizontalDirection != 0 || verticalDirection != 0)
        {
            var deltaX = horizontalDirection * speed * Time.deltaTime;
            var deltaY = verticalDirection * speed * Time.deltaTime;
            var newXPosition = transform.position.x + deltaX;
            var newYPosition = transform.position.y + deltaY;
            transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
        }
    }

    public void AnimationControl()
    {
        animator.SetBool("is-runningRight", horizontalDirection != 0);
        animator.SetBool("is-runningUp", verticalDirection > 0);
        animator.SetBool("is-runningDown", verticalDirection < 0);
    }

    private void Flip()
    {
        if (horizontalDirection < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }


}
