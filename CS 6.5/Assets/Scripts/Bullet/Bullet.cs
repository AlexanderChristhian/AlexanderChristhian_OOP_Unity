using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;

    public IObjectPool<Bullet> objectPool;

    IEnumerator DeactivateBullet(float delay)
    {
        yield return new WaitForSeconds(delay);

        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector3(0f, 0f, 0f);
        rBody.angularVelocity = 0f;
        objectPool.Release(this);
    }

    public void Deactivate ()
    {
        StartCoroutine(DeactivateBullet(2f));
    }
}
