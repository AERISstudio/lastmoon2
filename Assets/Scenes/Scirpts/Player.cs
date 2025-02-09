using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; // 캐릭터 이동 속도
    private Vector2 targetPosition; // 목표 위치
    private bool isMoving = false; // 이동 중인지 여부

    void Update()
    {
        // 마우스 오른쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 목표 위치를 마우스 위치로 설정
            targetPosition = mousePosition;
            // 이동 시작
            isMoving = true;
        }

        // 이동 중일 때
        if (isMoving)
        {
            // 프레임당 이동할 거리 계산
            float step = speed * Time.deltaTime;
            // 현재 위치에서 목표 위치로 이동
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

            // 목표 위치에 도달했는지 확인
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                // 이동 중지
                isMoving = false;
            }
        }
    }
}