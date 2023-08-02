using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 firstPos;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        firstPos = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * speed;

        if (firstPos.y - transform.position.y >= spriteRenderer.size.y / 3)
        {
            transform.position = firstPos;
        }
    }
}
