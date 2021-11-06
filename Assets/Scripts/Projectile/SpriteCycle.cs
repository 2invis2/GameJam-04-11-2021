using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCycle : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField]float stepTime = 0.1f;
    float timeLeft;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    int indexer = 0;
    private void Start()
    {
        if (sprites.Count < 1) { Destroy(this); return; }
        if (renderer == null) GetRenderer();
        renderer.sprite = sprites[0];
        timeLeft = stepTime;
    }
    private void Update()
    {
        if (timeLeft > 0f) timeLeft -= Time.deltaTime;
        else {
            indexer++;
            if (indexer >= sprites.Count) indexer = 0;
            renderer.sprite = sprites[indexer];
            timeLeft = stepTime;
        }
    }
    private void OnValidate()
    {
        if (renderer == null) GetRenderer();
    }
    void GetRenderer() {
        renderer = GetComponent<SpriteRenderer>();
    }
}
