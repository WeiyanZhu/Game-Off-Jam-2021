using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rigid;
    
    public virtual void Launch(Vector2 direction)
    {
        rigid.velocity = direction * speed;
    }
}
