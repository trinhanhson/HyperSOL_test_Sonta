using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] List<Transform> shootPoints;
    [SerializeField] float fireRate;

    private float timer;
    private Vector2 touchPosition;

    void Start()
    {
        timer = fireRate;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;
            }
            else
            {
                transform.Translate((touch.position - touchPosition).normalized * Time.deltaTime * speed);
            }
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(bulletPrefab, shootPoints[i].position, shootPoints[i].rotation);
            }

            timer = fireRate;
        }
    }
}
