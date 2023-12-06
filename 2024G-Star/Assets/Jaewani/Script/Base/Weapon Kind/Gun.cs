using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : IngameWeapon
{
    [Header("총알")]
    [SerializeField] protected GameObject bulletPrefabs;

    [Header("정보")]
    [SerializeField] private Transform firePos; // 발사위치
    [SerializeField] private Transform trueFlipFirePos;
    [SerializeField] private Transform falseFlipFirePos;

    protected virtual void Start()
    {
        flipYAction += SetFlipY;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        FireDelay();
        Fire();
    }

    protected virtual void Fire(Vector2 aim, float speed)
    {
        var bullet = Instantiate(bulletPrefabs, firePos.position, Quaternion.identity).GetComponent<GunBullet>();

        var dir = (aim - (Vector2)firePos.position).normalized;

        float x = aim.x - firePos.position.x;
        float y = aim.y - firePos.position.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullet.Init(dir, speed);

        canAttack = false;
    }
    private void FireDelay()
    {
        if (canAttack == false)
        {
            if (currentAttackDelay < attackDelay)
            {
                currentAttackDelay += Time.deltaTime;
                return;
            }
            else
            {
                canAttack = true;
                currentAttackDelay = 0;
            }
        }
    }
    private void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            if (canAttack)
            {
                Fire(aimDirection, attackSpeed);
            }
        }
    }

    private void SetFlipY()
    {
        if (WeaponFlipY == true) firePos = trueFlipFirePos;
        else firePos = falseFlipFirePos;
    }
}
