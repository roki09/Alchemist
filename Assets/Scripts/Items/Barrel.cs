using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private State state;
    private Animator animator;
    private Enemis enemis;
    public enum State
    {
        Idle,
        TakeDamage
    }


    private void Awake()
    {
        enemis = GetComponent<Enemis>();
        state = State.Idle;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StateOfBarrel();
    }

    private void StateOfBarrel()
    {
        switch (state)
        {
            case State.Idle:

                animator.SetBool("TakeDamage", enemis.takeDamage);

                if (enemis.takeDamage == true)
                    state = State.TakeDamage;
                break;
            case State.TakeDamage:

                animator.SetBool("TakeDamage", enemis.takeDamage);

                enemis.takeDamage = false;
                state = State.Idle;
                break;
        }
    }
}
