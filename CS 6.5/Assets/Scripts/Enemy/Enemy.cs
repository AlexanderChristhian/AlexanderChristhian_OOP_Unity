using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int level; 
    protected Vector2 screenBounds;
    protected Vector2 direction;
    protected float spriteHalfWidth;
    protected float spriteHalfHeight;

    protected virtual void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        spriteHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        Initialize();
    }

    void Update()
    {
        Move();
    }

    protected virtual void Initialize()
    {
        
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void Respawn()
    {
        
    }

    public int Level
    {
        get { return level; }
    }
}
