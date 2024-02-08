using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    [SerializeField] private HeroDirectionReader _heroPosition;
    [SerializeField] protected float speed = 0.02f;
    [SerializeField] private float _tempoSpeed = 0;
    [SerializeField] private SlimeStaits staits;
    public bool _heroIsNear;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        staits = GetComponent<SlimeStaits>();
    }

    private void Start()
    {
        //StartState();
    }

    private void FixedUpdate()
    {
        AnimationCotrol();
        if (_heroIsNear == true)
        {
            SlimeMove();
        }
        else
            _tempoSpeed = 0;
    }

    private async Task SlimeMove()
    {
        _tempoSpeed = speed;
        //animator.SetBool("move", true);
        transform.Translate((transform.position - _heroPosition.transform.position).normalized * speed);
    }


    //private async void StartState()
    //{

    //        await MovingUp(1);
    //        await MovingDown(1);
    //        await Timer();
    //}
    //private async Task MovingUp(float duration)
    //{
    //    var endOfMoving = Time.time + duration;
    //    while (Time.time < endOfMoving)
    //    {
    //        Debug.Log(endOfMoving);
    //        animator.SetBool("move", true);
    //        transform.Translate(Vector3.up * 0.003f);
    //        await Task.Yield();
    //    }
    //}
    //private async Task MovingDown(float duration)
    //{
    //    var endOfMoving = Time.time + duration;
    //    while (Time.time < endOfMoving)
    //    {
    //        Debug.Log(endOfMoving);
    //        animator.SetBool("move", true);
    //        transform.Translate(Vector3.down * 0.003f);
    //        await Task.Yield();
    //    }
    //}
    //private async Task Timer()
    //{
    //    await Task.Delay(1000);
    //}

    private void AnimationCotrol()
    {
        animator.SetBool("move", _tempoSpeed > 0);
    }

    private IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

}
