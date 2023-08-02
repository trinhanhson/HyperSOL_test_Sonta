using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private int destinationIndex;
    private float lerpT;
    private Vector2 prePosition;
    private Vector2 postPosition;

    private bool isFinishPre;
    private bool isFinish;
    private int upDownWay = 1;

    void Start()
    {
        destinationIndex = 0;

        lerpT = 0;

        prePosition = transform.position;

        isFinish = false;

        isFinishPre = false;
    }

    void Update()
    {
        if (isFinish)
        {
            transform.position = Vector2.Lerp(postPosition, postPosition + Vector2.up * 0.2f, lerpT);

            lerpT += Time.deltaTime * upDownWay * speed;

            if (lerpT < 0)
            {
                upDownWay = 1;
            }
            else if (lerpT > 1)
            {
                upDownWay = -1;
            }

            return;
        }

        if (!isFinishPre)
        {
            transform.position = Vector2.Lerp(prePosition, GameManager.Instance.prePositions[destinationIndex % GameManager.Instance.prePositions.Count], lerpT);

            lerpT += Time.deltaTime * speed;

            if (lerpT >= 1)
            {
                if (destinationIndex == GameManager.Instance.prePositions.Count)
                {
                    isFinishPre = true;
                }

                lerpT = 0;

                prePosition = GameManager.Instance.prePositions[destinationIndex % GameManager.Instance.prePositions.Count];

                destinationIndex++;
            }
        }
        else
        {
            transform.position = Vector2.Lerp(prePosition, postPosition, lerpT);

            lerpT += Time.deltaTime * speed;

            if (lerpT >= 1)
            {
                isFinish = true;

                lerpT = 0;
            }
        }

    }

    public void SetPostPosition(Vector2 _postPosition)
    {
        postPosition = _postPosition;
    }
}
