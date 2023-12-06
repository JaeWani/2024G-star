using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IngameWeapon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [Header("컴포넌트")]
    public SpriteRenderer spriteRenderer;

    [Header("스탯")]
    public float attackDelay;
    public float attackSpeed;

    [Header("상태")]
    [SerializeField] protected float currentAttackDelay;
    [SerializeField] protected bool canAttack;
    public Vector2 aimDirection;

    [SerializeField] private bool weaponFlipY = false;
    public bool WeaponFlipY
    {
        get { return weaponFlipY; }
        set
        {
            weaponFlipY = value;
            spriteRenderer.flipY = weaponFlipY;
            flipYAction.Invoke();
        }
    }
    [Header("액션")]
    protected Action flipYAction;

    void Start()
    {
        
    }

    void Update()
    {

    }
}
