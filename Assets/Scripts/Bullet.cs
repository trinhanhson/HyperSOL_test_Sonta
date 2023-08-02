using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.position += (transform.up * Time.deltaTime * speed);

        if (Mathf.Abs(transform.position.y) >= 6)
        {
            Destroy(gameObject);
        }
    }
}
