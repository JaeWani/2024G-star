using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;

    public void Init(Vector2 dir, float speed)
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = dir * speed;

        Destroy(gameObject, 4f);
    }
}
