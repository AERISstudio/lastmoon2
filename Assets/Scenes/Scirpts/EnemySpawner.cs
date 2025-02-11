using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public float spawnInterval = 2.0f; // 스폰 간격
    public Vector2 spawnAreaMin; // 스폰 영역 최소 좌표
    public Vector2 spawnAreaMax; // 스폰 영역 최대 좌표
    public bool die = false;
    void Start()
    {
        // 일정 시간마다 적을 스폰
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 스폰 영역 내에서 랜덤 위치 생성
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        die = false;
        // 적 오브젝트 생성
        GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        if (die){
            Destroy(clone);
        }
    }
    
}
