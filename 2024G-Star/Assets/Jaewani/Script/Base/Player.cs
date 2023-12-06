using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject Aim;
    [SerializeField] private GameObject WeaponObject;

    [Header("스탯")]
    [SerializeField] private float MoveSpeed;

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
        Aim.transform.position = new Vector3(pos.x, pos.y,0);
    }
    private void WeaponRotation() 
    {
        var weaponTransform = WeaponObject.transform;
        var mousePos = GameManager.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float y = mousePos.y - weaponTransform.position.y;
        float x = mousePos.x - weaponTransform.position.x;

        float angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg;

        weaponTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (angle < 90 && angle > -90) WeaponObject.GetComponent<SpriteRenderer>().flipY = false;
        else WeaponObject.GetComponent<SpriteRenderer>().flipY = true;
    }
}
