using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    private HandsBase currentWeapon;

    private void Awake()
    {
        currentWeapon = GetComponent<HandsBase>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.CompareTag("Enemis"))
        {
            collision.gameObject.TryGetComponent<Enemis>(out var enemis);
            Debug.Log("GetDamage");

            if (enemis._currentHealth > 0)
            {
                enemis.takeDamage = true;
                enemis._currentHealth -= currentWeapon.equippedItem._damage;
            }

            if (enemis._currentHealth <= 0)
                enemis.EnemisDead();
        }
    }
}
