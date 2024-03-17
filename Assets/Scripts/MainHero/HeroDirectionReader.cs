using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDirectionReader : MonoBehaviour, IMovable
{

    [SerializeField] public Vector3 direction;
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
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
        AnimationControl();
    }

    public void SetDirection()
    {
       direction = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void Move()
    {
        if(direction.x != 0 || direction.y != 0)
        {
            var deltaX = direction.x * speed * Time.deltaTime;
            var deltaY = direction.y * speed * Time.deltaTime;

            var newXPosition = transform.position.x + deltaX;
            var newYPosition = transform.position.y + deltaY;

            transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
        }
    }

    public void AnimationControl()
    {
        animator.SetBool("is-runningRight", direction.x != 0);
        animator.SetBool("is-runningUp", direction.y > 0);
        animator.SetBool("is-runningDown", direction.y < 0);
    }

    private void Flip()
    {
        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }


}
