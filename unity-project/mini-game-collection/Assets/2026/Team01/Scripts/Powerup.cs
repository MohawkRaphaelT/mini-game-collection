using MiniGameCollection.Games2026.Team01;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [field: SerializeField] public float SpeedBoost { get; private set; }
    [field: SerializeField] public float EffectLength { get; private set; }
    [field: SerializeField] public float RespawnTimer { get; private set; }
    private SpriteRenderer SpriteRenderer;
    private CircleCollider2D CircleCollider2D;

    private void Awake()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TagPlayer>()) // Check for player
        {
            StartCoroutine(ChangeSpeed(collision.GetComponent<PlayerController>()));
            StartCoroutine(Respawn());
            
        }
    }
    private IEnumerator ChangeSpeed(PlayerController Player)
    {
        // Change Speed
        Player.SpeedBoost = SpeedBoost;
        yield return new WaitForSeconds(EffectLength);
        // Change Back Speed
        Player.SpeedBoost = 0f;
    }
    private IEnumerator Respawn()
    {

        SpriteRenderer.enabled = false;
        CircleCollider2D.enabled = false;
        yield return new WaitForSeconds(RespawnTimer);
        SpriteRenderer.enabled = true;
        CircleCollider2D.enabled = true;

    }
}
