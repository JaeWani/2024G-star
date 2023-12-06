using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IngameWeapon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [Header("������Ʈ")]
    public SpriteRenderer spriteRenderer;

    [Header("����")]
    public float attackDelay;
    public float attackSpeed;

    [Header("����")]
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
    [Header("�׼�")]
    protected Action flipYAction;

    void Start()
    {
        
    }

    void Update()
    {

    }
}
