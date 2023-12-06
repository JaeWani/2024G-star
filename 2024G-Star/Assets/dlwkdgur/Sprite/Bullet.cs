using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : player
{
    public float speed = 30f;

    void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            hp--;
            
        }
    }
}
