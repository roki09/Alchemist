using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    [SerializeField] private HeroDirectionReader _heroPosition;
    [SerializeField] protected float speed = 1;
    [SerializeField] private float _tempoSpeed = 0;
    public bool _heroIsNear;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        AnimationCotrol();
        SlimeRunAway();
    }


    private void SlimeRunAway()
    {
        if (_heroIsNear == true)
            SlimeMove();
        else
            _tempoSpeed = 0;
    }
    private void SlimeMove()
    {
        _tempoSpeed = speed;
        transform.Translate((transform.position - _heroPosition.transform.position).normalized * speed * Time.deltaTime);
    }


    private void AnimationCotrol()
    {
        animator.SetBool("move", _tempoSpeed > 0);
    }


}
