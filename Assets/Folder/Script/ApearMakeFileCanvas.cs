using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEventManager : MonoBehaviour
{
    public CanvasGroup canvas1; // 기존 캔버스 (20% 불투명)
    public CanvasGroup canvas2; // 새로 나타날 캔버스 (페이드 인)
    public Button startButton; // 스타트 버튼
    public float fadeDuration = 1.5f; // 페이드 지속 시간
    private float canvas1FinalAlpha = 0.2f; // 기존 캔버스를 20% 불투명하게 유지

    void Start()
    {
        // 처음에는 Canvas2를 투명하게 설정
        canvas2.alpha = 0f;
        canvas2.gameObject.SetActive(false);

        // 버튼 클릭 이벤트 등록
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        StartCoroutine(FadeOutIn());
    }

    IEnumerator FadeOutIn()
    {
        // 캔버스1을 20% 불투명하게 만들기 (완전히 안 사라지게)
        if (canvas1 != null)
        {
            yield return StartCoroutine(FadeCanvas(canvas1, canvas1FinalAlpha));
        }

        // 캔버스2 페이드 인 (서서히 나타남)
        if (canvas2 != null)
        {
            canvas2.gameObject.SetActive(true);
            yield return StartCoroutine(FadeCanvas(canvas2, 1f));
        }
    }

    IEnumerator FadeCanvas(CanvasGroup canvasGroup, float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha; // 최종값 보정
    }
}