using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCycle : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField]float stepTime = 0.1f;
    float timeLeft;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    int indexer = 0;
    private void Start()
    {
        if (sprites.Count < 1) { Destroy(this); return; }
        if (spriteRenderer == null) GetRenderer();
        spriteRenderer.sprite = sprites[0];
        timeLeft = stepTime;
    }
    private void Update()
    {
        if (timeLeft > 0f) timeLeft -= Time.deltaTime;
        else {
            indexer++;
            if (indexer >= sprites.Count) indexer = 0;
            spriteRenderer.sprite = sprites[indexer];
            timeLeft = stepTime;
        }
    }
    private void OnValidate()
    {
        if (spriteRenderer == null) GetRenderer();
    }
    void GetRenderer() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
