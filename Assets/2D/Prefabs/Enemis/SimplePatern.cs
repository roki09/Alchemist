using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimplePatern : MonoBehaviour
{
    [SerializeField] private bool heroIsNear;
    [SerializeField] private State startingState;
    [SerializeField] private float _roamingMaxDistance = 5f;
    [SerializeField] private float _roamingMinDistance = 2f;
    [SerializeField] private float _roamingMaxTimer = 2f;
    [SerializeField] private float _speed;

    private State state;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startPosition;
    private enum State
    {
        Idle = 1,
        Roaming = 2,
        RunAway
    }

    private void Awake()
    {
        roamingPosition = GetRoamingPosition();
        startPosition = transform.position;
        state = startingState;
    }

    private void FixedUpdate()
    {
        StateOfAction();
    }


    private void StateOfAction()
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log(roamingPosition = GetRoamingPosition());
                break;
            case State.Roaming:
                transform.position = Vector2.MoveTowards(transform.position, roamingPosition, _speed * Time.deltaTime);
                //roamingTime -= Time.deltaTime;
                //if (roamingTime < 0)
                //{
                //    Roaming();
                //    roamingTime = _roamingMaxTimer;
                //}
                break;
            case State.RunAway:
                break;
            default:
                break;
        }
    }

    private IEnumerator Timer()
    {
        transform.Translate(roamingPosition * _speed);
        yield return new WaitForSeconds(5);
        roamingTime = _roamingMaxTimer;

    }
    private void Roaming()
    {
        //roamingPosition = GetRoamingPosition();
        transform.position = Vector2.MoveTowards(transform.position, roamingPosition, _speed * Time.deltaTime);
    }

    private Vector3 GetRoamingPosition()
    {
        return startPosition + GetRandomDirection() * Random.Range(_roamingMinDistance, _roamingMaxDistance);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    //private void GetState()
    //{
    //    state = State.Idle;
    //}
    //private void GetState(bool HeroIsNear)
    //{
    //    if(HeroIsNear == true)

    //        state = State.RunAway;
    //    else
    //    state = State.Roaming;
    //}
}
