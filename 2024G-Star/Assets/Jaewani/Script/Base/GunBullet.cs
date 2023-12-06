using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public void Init(Vector2 dir, float speed) 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = dir * speed;
    }
}
