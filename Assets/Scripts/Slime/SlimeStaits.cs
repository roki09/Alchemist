using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlimeStaits : MonoBehaviour
{
    public async Task MovingUp(float duration)
    {
        var endOfMoving = Time.time + duration;
        while (Time.time < endOfMoving)
        {
            Debug.Log(endOfMoving);
            transform.Translate(Vector3.up * 0.01f);
            await Task.Yield();
        }
    }
}
