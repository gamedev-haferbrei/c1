using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWhenInvisible : MonoBehaviour
{
    int invisibleFrames = 0;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        invisibleFrames = spriteRenderer.isVisible ? 0 : invisibleFrames + 1;

        if (invisibleFrames > 60) Destroy(gameObject);
    }
}
