using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }

    protected virtual void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector2(x, y).normalized * MoveSpeed;
    }
}
