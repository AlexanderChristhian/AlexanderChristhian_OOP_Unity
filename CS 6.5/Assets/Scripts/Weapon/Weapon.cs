using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;
    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;
    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;
    public Transform parentTransform;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, onGetFromPool, onReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }

    Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.objectPool = objectPool;
        return newBullet;
    }

    void onGetFromPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    void onReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    void OnDestroyPooledObject (Bullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > timer && objectPool != null)
        {
            Bullet bulletObject = objectPool.Get();

            if(bulletObject == null)
            {
                return;
            }
            
            bullet.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);

            bulletObject.GetComponent<Rigidbody2D>().AddForce(bulletSpawnPoint.up * bulletObject.bulletSpeed, ForceMode2D.Force);
            
            bulletObject.Deactivate();  

            timer = Time.time + shootIntervalInSeconds;
        }
    }
}
