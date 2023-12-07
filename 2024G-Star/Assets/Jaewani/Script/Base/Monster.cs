using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("정보")]
    [SerializeField] public GameObject curPlayer;

    [Header("스탯")]
    [SerializeField] protected float hp;
    protected float Hp
    {
        get => hp;
        set
        {
            hp = value;
            CheckHp();
        }
    }
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackDelay;

    [Header("현재 상태")]
    [SerializeField] protected float curAttackDelay;
    protected bool isDelay = true;

    [Header("설정")]
    [SerializeField] protected bool isAttackLoop; // 어택이 주기적으로 공격을 할 지 말지
    [SerializeField] protected bool isTrace; // 플레이어 방향으로 추격 할 지 말지

    [Header("컴포넌트")]
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Attack()
    {

    }

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        curPlayer = GameManager.instance.Player;

    }

    protected virtual void Update()
    {
        AttackLoop();
        Trace();
    }

    private void AttackLoop()
    {
        if (isAttackLoop)
        {
            if (isDelay) curAttackDelay += Time.deltaTime;
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
        if (isTrace) rigidBody.velocity = (transform.position - curPlayer.transform.position).normalized * moveSpeed;
    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }
    private void CheckHp()
    {
        Debug.Log("check");
        if(hp <= 0)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
}
