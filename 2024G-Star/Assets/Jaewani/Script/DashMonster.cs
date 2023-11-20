using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMonster : Monster
{
    [SerializeField]
    private Transform target;
    Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position);

        if (dis <= 10)
        {
            Attack();
        }
    }


    protected override void Attack()
    {

        Vector3 moveDirection = (target.position - transform.position).normalized;

        rigid.AddForce(moveDirection, ForceMode2D.Impulse);
    }
}
