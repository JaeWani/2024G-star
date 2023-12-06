using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMonster : Monster
{
    [Header("DashMonster")]
    [SerializeField] private float dashPower;
    protected override void Start()
    {
        base.Start();
        isAttackLoop = true;
    }

    protected override void Attack()
    {
        rigidBody.velocity = Vector2.zero;
        Vector3 moveDirection = (curPlayer.transform.position - transform.position).normalized;
        rigidBody.AddForce(moveDirection * dashPower, ForceMode2D.Impulse);
    }
}
