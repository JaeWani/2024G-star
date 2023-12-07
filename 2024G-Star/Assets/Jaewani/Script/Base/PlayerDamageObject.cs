using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageObject : MonoBehaviour
{
    public float Damage;

    [SerializeField] protected bool isDestroy;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            if(other.gameObject.TryGetComponent<Monster>(out Monster monster))
            {
                monster.Hit(Damage);
                if(isDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
