using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : SlimeBase, IMovable
{

    [SerializeField] private List<Projectiles> _projectaile = new List<Projectiles>();

    public override void SlimeAction()
    {
        base.SlimeAction();
        RespawnProjectaile();
    }

    private void RespawnProjectaile()
    {
        foreach (var item in _projectaile)
        {
            if (!item.isActiveAndEnabled)
                StartCoroutine(Respawn(item));
            else if (item.isActiveAndEnabled && item.flies == false)
                item.Throw();
        }
    }

    private IEnumerator Respawn(Projectiles obj)
    {
        yield return new WaitForSeconds(3);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(true);
    }

    public override void Move()
    {
        transform.Translate((_heroPosition.transform.position - transform.position).normalized * _speed * Time.deltaTime);
    }
}
