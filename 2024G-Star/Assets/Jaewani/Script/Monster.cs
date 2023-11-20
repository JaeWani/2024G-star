using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   [Header("정보")]
   [SerializeField] public GameObject curPlayer;

   [Header("스탯")]
   [SerializeField] protected float moveSpeed;
   [SerializeField] protected float hp;
   [SerializeField] protected float damage;
   [SerializeField] protected float attackDelay;

   [Header("현재 상태")]
   protected float curAttackDelay;
   protected bool isDelay = true;

   [Header("설정")]
   protected bool isAttackLoop;
   protected bool isTrace;

   [Header("컴포넌트")]
   protected Rigidbody2D rb;

   protected virtual void Attack()
   {

   }

   protected virtual void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      curPlayer = GameManager.instance.Player;
   }

   private void Update()
   {
      AttackLoop();
      Trace();
   }

   private void AttackLoop()
   {
      if (isAttackLoop)
      {
         if(isDelay) curAttackDelay += Time.deltaTime;
         if (curAttackDelay >= attackDelay)
         {
            Attack();
            curAttackDelay = 0;
         }
         else return;
      }
   }

   private void Trace()
   {
      if (isTrace) rb.velocity = (transform.position - curPlayer.transform.position).normalized * moveSpeed;
   }
}
