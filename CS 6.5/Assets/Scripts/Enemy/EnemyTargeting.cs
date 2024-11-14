using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform player;
    private Coroutine followCoroutine;

    protected override void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float spawnX;
        if (Random.Range(0, 2) == 0)
        {
            spawnX = -screenBounds.x - spriteHalfWidth;
        }
        else
        {
            spawnX = screenBounds.x + spriteHalfWidth;
        }
        float spawnY = Random.Range((-screenBounds.y + spriteHalfHeight)/2, screenBounds.y - spriteHalfHeight);
        transform.position = new Vector2(spawnX, spawnY);
        followCoroutine = StartCoroutine(FollowPlayer());
    }

    private IEnumerator FollowPlayer()
    {
        while (true)
        {
            if (player != null)
            {
                Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
                transform.Translate((-direction) * speed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Respawn();
        }
    }

    private void OnDestroy()
    {
        if (followCoroutine != null)
        {
            StopCoroutine(followCoroutine);
        }
    }

    protected override void Respawn()
    {
        float spawnX;
        if (Random.Range(0, 2) == 0)
        {
            spawnX = -screenBounds.x - spriteHalfWidth;
        }
        else
        {
            spawnX = screenBounds.x + spriteHalfWidth;
        }
        float spawnY = Random.Range(-screenBounds.y + spriteHalfHeight, screenBounds.y - spriteHalfHeight);
        transform.position = new Vector2(spawnX, spawnY);
        gameObject.SetActive(true);
    }
}
