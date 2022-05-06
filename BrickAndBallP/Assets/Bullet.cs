using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bounces = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BottomCollider")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Block")
        {
            bounces++;
            if (bounces >= 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
