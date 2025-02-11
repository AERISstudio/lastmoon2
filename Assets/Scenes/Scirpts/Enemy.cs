using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f; // 적 이동 속도
    private Transform player; // 플레이어의 Transform

    void Start()
    {
        // 플레이어 오브젝트를 찾고 Transform을 저장
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // 플레이어를 향해 이동
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    
}