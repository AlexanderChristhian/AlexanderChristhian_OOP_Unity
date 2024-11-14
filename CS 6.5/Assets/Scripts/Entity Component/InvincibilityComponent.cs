using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 3;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            GameObject ship = GameObject.Find("Ship");
            if (ship != null)
            {
                spriteRenderer = ship.GetComponent<SpriteRenderer>();
            }
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        originalMaterial = spriteRenderer.material;
    }

    public void TriggerInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(BlinkingEffect());
        }
    }

    private IEnumerator BlinkingEffect()
    {
        isInvincible = true;
        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }
        isInvincible = false;
    }

}
