using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  // config params
  [SerializeField] AudioClip destroySound;
  [SerializeField] GameObject blockParticle;
  [SerializeField] int maxHits;
  [SerializeField] Sprite[] hitSprites;

  // cached reference
  Level level;
  GameSession gameStatus;

  // state
  [SerializeField] int timesHit; // TODO serialized only for debug purposes

  private void Start()
  {
    gameStatus = FindObjectOfType<GameSession>();
    CountBreakableBlocks();
  }

  private void CountBreakableBlocks()
  {
    level = FindObjectOfType<Level>();
    if (tag == "Breakable")
    {
      level.CountBlocks();
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (tag == "Breakable")
    {

      HandleHit();
    }
  }

  private void HandleHit()
  {
    timesHit++;
    if (timesHit >= maxHits)
    {
      DestroyBlock();
    }
    else
    {
      ShowNextHitSprite();
    }
  }

  private void ShowNextHitSprite()
  {
    int hitIndex = timesHit - 1;
    GetComponent<SpriteRenderer>().sprite = hitSprites[hitIndex];
  }

  private void DestroyBlock()
  {
    gameStatus.AddToScore();
    AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
    Destroy(gameObject);
    level.BlockDestroyed();
    TriggerBlockParticlesVFX();
  }

  private void TriggerBlockParticlesVFX()
  {
    GameObject sparkles = Instantiate(blockParticle, transform.position, transform.rotation);
    Destroy(sparkles, 1f);
  }
}
