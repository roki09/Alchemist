using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeBase : MonoBehaviour, IMovable
{
    [SerializeField] protected HeroDirectionReader _heroPosition;
    [SerializeField] protected float _speed = 1;
    [SerializeField] protected Enemis _enemis;
    [SerializeField] protected State _state;


    public bool _heroIsNear;
    protected bool isMoving = false;
    protected Collider2D currentCollider;

    public enum State
    {
        Idle,
        RunAway,
        TakeDamage
    };

    protected Animator animator;


    private void Awake()
    {
        currentCollider = GetComponent<Collider2D>();
        _state = State.Idle;
        _enemis = GetComponent<Enemis>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        SlimeState();
    }

    private void SlimeState()
    {
        switch (_state)
        {
            case State.Idle:
                isMoving = false;
                AnimationCotrol();
                if (_heroIsNear == true)
                    _state = State.RunAway;
                else if (_enemis.takeDamage == true)
                    _state = State.TakeDamage;
                break;

            case State.RunAway:
                isMoving = true;
                if (_heroIsNear == false)
                {
                    _state = State.Idle;
                }
                else if (_enemis.takeDamage == true)
                {
                    _state = State.TakeDamage;
                }

                AnimationCotrol();
                SlimeAction();
                break;

            case State.TakeDamage:
                if (_enemis._currentHealth <= 0)
                    _state = State.Idle;
                currentCollider.enabled = false;
                isMoving = false;
                AnimationCotrol();
                _enemis.takeDamage = false;

                transform.DOShakeScale(0.4f, 0.2f, 0, 3, true, ShakeRandomnessMode.Harmonic)
                    .SetLink(gameObject)
                    .OnKill(() => SwitchToIdle());
                break;
        }

    }

    public virtual void SlimeAction()
    {
        Move();
    }

    private void AnimationCotrol()
    {
        //animator.SetBool("move", _tempoSpeed > 0);
        animator.SetBool("move", isMoving);
        animator.SetBool("takeDamage", _enemis.takeDamage == true);
    }

    private void SwitchToIdle()
    {
        _state = State.Idle;
        currentCollider.enabled = true;
    }
    public virtual void Move()
    {
        transform.Translate((transform.position - _heroPosition.transform.position).normalized * _speed * Time.deltaTime);
    }
}
