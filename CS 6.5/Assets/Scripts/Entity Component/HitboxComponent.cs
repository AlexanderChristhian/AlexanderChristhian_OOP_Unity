using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] public HealthComponent health;

    public void Damage(int damage)
    {
        health.Subtract(damage);
    }

    public void Damage(Bullet bullet)
    {
        health.Subtract(bullet.damage);
    }
}
