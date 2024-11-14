using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] public HealthComponent health;

    public void Damage(int damage)
    {
        var invincibilityComponent = GetComponent<InvincibilityComponent>();
        if (invincibilityComponent == null || !invincibilityComponent.isInvincible)
        {
            health.Subtract(damage);
        }
    }

    public void Damage(Bullet bullet)
    {
        var invincibilityComponent = GetComponent<InvincibilityComponent>();
        if (invincibilityComponent == null || !invincibilityComponent.isInvincible)
        {
            health.Subtract(bullet.damage);
        }
    }
}
