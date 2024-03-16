using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimaBase : MonoBehaviour
{

    [SerializeField] private HeroDirectionReader _heroPosition;
    [SerializeField] protected float _speed = 1;
    [SerializeField] private float _time = 0;
    [SerializeField] private EnemisBase _enemis;
    [SerializeField] private State _state;
    [SerializeField] private List<Projectails> _projectaile = new List<Projectails>();


    public bool _heroIsNear;
    private bool isMoving = false;
    private Collider2D currentCollider;

    public enum State
    {
        Idle,
        RunAway,
        TakeDamage
    };

    private Animator animator;


    private void Awake()
    {
        currentCollider = GetComponent<Collider2D>();
        _state = State.Idle;
        _enemis = GetComponent<EnemisBase>();
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

                ThrowProjectaile();
                AnimationCotrol();
                SlimeMove();
                break;

            case State.TakeDamage:
                if (_enemis._currentHealth <= 0)
                    _state = State.Idle;
                currentCollider.enabled = false;
                isMoving = false;
                AnimationCotrol();
                _enemis.takeDamage = false;

                transform.DOShakeScale(0.4f, 0, 0, 3, true, ShakeRandomnessMode.Harmonic).OnComplete(() => SwitchToIdle());
                break;
        }

    }

    private void AnimationCotrol()
    {
        //animator.SetBool("move", _tempoSpeed > 0);
        animator.SetBool("Move", isMoving);
        animator.SetBool("TakeDamage", _enemis.takeDamage == true);
    }

    private void SwitchToIdle()
    {
        _state = State.Idle;
        currentCollider.enabled = true;
    }
    private void SlimeMove()
    {
        transform.Translate((_heroPosition.transform.position - transform.position).normalized * _speed * Time.deltaTime);
    }

    private void ThrowProjectaile()
    {
        foreach (var item in _projectaile)
        {
            if (!item.isActiveAndEnabled)
                StartCoroutine(Respawn(item));
        }
    }

    private IEnumerator Respawn(Projectails obj)
    {
        yield return new WaitForSeconds(3);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(true);
    }
}
