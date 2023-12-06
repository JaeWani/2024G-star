using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class archerMonster : Monster
{

    [SerializeField]
    private GameObject bulletPrefabs;

    public float bulletSpeed = 10f;

    protected override void Update()
    {
        base.Update();
    }

    protected override void Start()
    {

    }

    protected override void Attack()
    {
        //플레이어의 위치
        Vector2 playerPos = curPlayer.transform.position;
        //몬스터의 위치(내 위치)
        Vector2 Pos = transform.position;
        //방향 벡터(플레이어와 내 위치와의 차)
        Vector2 dir = (playerPos - Pos).normalized;


        InstantiateBullet(dir);

        // 두 번째 방향 (시계 방향으로 30도 회전)
        Quaternion rotation30 = Quaternion.Euler(0, 0, 30);
        Vector2 dir30 = rotation30 * dir;
        InstantiateBullet(dir30);

        // 세 번째 방향 (반시계 방향으로 30도 회전)
        Quaternion rotationMinus30 = Quaternion.Euler(0, 0, -30);
        Vector2 dirMinus30 = rotationMinus30 * dir;
        InstantiateBullet(dirMinus30);
    }

    void InstantiateBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(direction.normalized, bulletSpeed);
    }

    
}






