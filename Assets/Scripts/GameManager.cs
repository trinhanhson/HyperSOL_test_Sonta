using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Vector2> prePositions;

    [SerializeField] List<Vector2> postPositions;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate;

    public static GameManager Instance;

    private int enemyCount;

    void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int index = 0;

        while (enemyCount < postPositions.Count)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(0, Camera.main.orthographicSize + 1), Quaternion.identity);

            enemy.GetComponent<Enemy>().SetPostPosition(postPositions[index]);

            index++;

            enemyCount++;

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
