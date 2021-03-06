using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameover;
    public List<Vector3> targetPositions;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    private float spawnRate = 2f;
    private Vector3 randomPos;

    void Start()
    {
        StartCoroutine(SpawnRandomTarget());
    }


    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltosX = Random.Range(0, 4);
        int SaltosY = Random.Range(0, 4);

        float SpawnPosX = minX + SaltosX * distanceBetweenSquares;
        float SpawnPosY = minX + SaltosY * distanceBetweenSquares;

        return new Vector3(SpawnPosX, SpawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        yield return new WaitForSeconds(spawnRate);
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        randomPos = RandomSpawnPosition();
        while (targetPositions.Contains(randomPos))
        {
            randomPos = RandomSpawnPosition();
        }

        Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
        targetPositions.Add(randomPos);
    }
}
