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
        //�÷��̾��� ��ġ
        Vector2 playerPos = curPlayer.transform.position;
        //������ ��ġ(�� ��ġ)
        Vector2 Pos = transform.position;
        //���� ����(�÷��̾�� �� ��ġ���� ��)
        Vector2 dir = (playerPos - Pos).normalized;


        InstantiateBullet(dir);

        // �� ��° ���� (�ð� �������� 30�� ȸ��)
        Quaternion rotation30 = Quaternion.Euler(0, 0, 30);
        Vector2 dir30 = rotation30 * dir;
        InstantiateBullet(dir30);

        // �� ��° ���� (�ݽð� �������� 30�� ȸ��)
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






