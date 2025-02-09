using UnityEngine;

public class MouseToStart : MonoBehaviour
{
    public GameObject targetObject;  // 서서히 나타날 오브젝트
    public float fadeDuration = 1.5f; // 페이드 인 지속 시간

    private CanvasGroup canvasGroup;
    private bool isFading = false;

    void Start()
    {
        // 대상 오브젝트에서 CanvasGroup 가져오기, 없으면 추가
        canvasGroup = targetObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = targetObject.AddComponent<CanvasGroup>();
        }

        // 처음에는 투명하게 설정
        canvasGroup.alpha = 0f;
        targetObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFading) // 마우스 왼쪽 버튼 클릭
        {
            StartCoroutine(FadeIn());
        }
    }

    System.Collections.IEnumerator FadeIn()
    {
        isFading = true;
        targetObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        isFading = false;
    }
}
