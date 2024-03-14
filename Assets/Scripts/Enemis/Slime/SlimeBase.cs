using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    [SerializeField] private HeroDirectionReader _heroPosition;
    [SerializeField] protected float speed = 1;
    [SerializeField] private float time = 0;
    [SerializeField] private EnemisBase enemis;
    [SerializeField] private State state;


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
        state = State.Idle;
        enemis = GetComponent<EnemisBase>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        SlimeState();
    }

    private void SlimeState()
    {
        switch (state)
        {
            case State.Idle:
                isMoving = false;
                AnimationCotrol();
                if (_heroIsNear == true)
                    state = State.RunAway;
                else if (enemis.takeDamage == true)
                    state = State.TakeDamage;
                break;

            case State.RunAway:
                isMoving = true;
                if (_heroIsNear == false)
                {
                    state = State.Idle;
                }
                else if (enemis.takeDamage == true)
                {
                    state = State.TakeDamage;
                }

                AnimationCotrol();
                SlimeMove();
                break;

            case State.TakeDamage:
                if (enemis._currentHealth <= 0)
                    state = State.Idle;
                currentCollider.enabled = false;
                isMoving = false;
                AnimationCotrol();
                enemis.takeDamage = false;

                transform.DOShakeScale(0.4f, 0.2f, 0, 3, true, ShakeRandomnessMode.Harmonic).OnComplete(() => SwitchToIdle());
                break;
        }

    }

    private void AnimationCotrol()
    {
        //animator.SetBool("move", _tempoSpeed > 0);
        animator.SetBool("move", isMoving);
        animator.SetBool("takeDamage", enemis.takeDamage == true);
    }

    private void SwitchToIdle()
    {
        state = State.Idle;
        currentCollider.enabled = true;
    }
    private void SlimeMove()
    {
        transform.Translate((transform.position - _heroPosition.transform.position).normalized * speed * Time.deltaTime);
    }



}
