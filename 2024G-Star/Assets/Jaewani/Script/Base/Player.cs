using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject Aim;
    [SerializeField] private GameObject weaponObject;
    public GameObject WeaponObject
    {
        get { return weaponObject; } 
        set
        {
            weaponObject = value;
            ingameWeapon = weaponObject.GetComponent<IngameWeapon>();
        }
    }
    [SerializeField] private IngameWeapon ingameWeapon;


    [Header("스탯")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            CheckHp();
        }
    }

    [Header("컴포넌트")]
    private Rigidbody2D Rb;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        Move();
        AimMove();
        WeaponRotation();
        WeaponInit();
    }

    protected virtual void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector2(x, y).normalized * MoveSpeed;
    }
    
    private void AimMove()
    {
        var mousePos = Input.mousePosition;
        var pos = GameManager.instance.mainCamera.ScreenToWorldPoint(mousePos);
        Aim.transform.position = new Vector3(pos.x, pos.y, 0);
    }
    private void WeaponRotation()
    {
        var weaponTransform = WeaponObject.transform;
        var mousePos = GameManager.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float y = mousePos.y - weaponTransform.position.y;
        float x = mousePos.x - weaponTransform.position.x;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        weaponTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (angle < 90 && angle > -90) ingameWeapon.WeaponFlipY = false;
        else ingameWeapon.WeaponFlipY = true;
    }
    private void WeaponInit()
    {
        ingameWeapon.aimDirection = GameManager.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Hit(float damage)
    {
        Hp -= damage;
    }
    private void CheckHp()
    {
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
