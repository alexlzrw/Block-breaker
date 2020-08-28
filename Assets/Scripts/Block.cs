using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;       
    [SerializeField] GameObject blockSparkles;
    [SerializeField] int maxHit;
    [SerializeField] int timeHit;
    [SerializeField] Sprite[] hitSprites;
    

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timeHit++;
        if (timeHit == maxHit)
        {
            DestroryBlock(); 
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timeHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroryBlock() 
    {
        PlaySoundBlock();
        level.BlockDestroy();
        TriggerSparkles();
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
   
    private void PlaySoundBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
