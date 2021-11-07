using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAppearAndBlow : MonoBehaviour
{
    [SerializeField] float resolveTime = 2f;
    [SerializeField] float stayTime = 1f;
    //TODO repace with animation
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] List<Sprite> spritesProgress = new List<Sprite>();
    [SerializeField] Sprite spriteDanger;
    [SerializeField] Collider2D zoneCollider;
    int index = 0;
    //TODO make it use radius
    //[SerializeField] float radius = 1.49f;
    public GameObject sender;
    private void Start()
    {
        //if (spritesProgress == null || spritesProgress.Count == 0) spritesProgress.Add(spriteRenderer.sprite);
        zoneCollider.enabled = false;
        StartCoroutine(Resolve());
    }
    IEnumerator Resolve() {
        float time = 0f;
        index = 0;
        spriteRenderer.sprite = spritesProgress[0];
        while (time < resolveTime) {
            var colorVal = 0.2f + time / resolveTime * 0.8f;
            Color newColor =
                //spriteRenderer.color;
                new Color(colorVal, colorVal, colorVal, colorVal);
            //newColor.a =
            //    //0.5f + time / resolveTime * 0.5f;
            //    0.2f + time / resolveTime * 0.8f;
            spriteRenderer.color = newColor;
            int curInd = Mathf.FloorToInt(spritesProgress.Count * time / resolveTime);
            if (curInd != index) {
                index = curInd;
                spriteRenderer.sprite = spritesProgress[index];
            }
            time += Time.deltaTime;
            yield return null;
        }
        Color fullColor =
            //spriteRenderer.color;
            Color.white;
        //fullColor.a = 1f;
        spriteRenderer.color = fullColor;
        spriteRenderer.sprite = spriteDanger;
        zoneCollider.enabled = true;
        time = 0f;
        while (time < stayTime) {
            time += Time.deltaTime;
            yield return null;
        }
        Finished();
        yield break;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHP>().ProjectileHit(sender);
            Finished();
        }

        if (!other.gameObject.Equals(sender))
        {
            Finished();
        }

    }
    private void Finished()
    {
        Destroy(gameObject);
    }
}
