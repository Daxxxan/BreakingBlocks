using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    int maxHits;
    [SerializeField] Sprite[] hitSprites;
    Level level;
    GameStatus gameStatus;
    [SerializeField] int timesHit;

    void Start()
    {
        maxHits = hitSprites.Length + 1;
        level = FindObjectOfType<Level>();
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks() {
        if(tag == "Breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(tag == "Breakable") {
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit++;
        if(timesHit == maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerSparklesVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        gameStatus.AddPoints();
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2);
    }
}
