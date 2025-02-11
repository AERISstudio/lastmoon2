using UnityEngine;
using UnityEngine.UI;

public class SettingCanvasManger : MonoBehaviour
{
    public Button settingButton; // 설정 버튼
    public GameObject settingCanvas; // 설정 창(Canvas)
    public GameObject mainCanvas; // 메인 캔버스
    public float fadeDuration = 1.5f; // 페이드 인 지속 시간
    private float mainCanvasFinalAlpha = 0.2f; // 20% opacity

    private CanvasGroup settingCanvasGroup;
    private CanvasGroup mainCanvasGroup;
    private bool isFading = false;

    void Start()
    {
        // 대상 오브젝트에서 CanvasGroup 가져오기, 없으면 추가
        settingCanvasGroup = settingCanvas.GetComponent<CanvasGroup>();
        if (settingCanvasGroup == null)
        {
            settingCanvasGroup = settingCanvas.AddComponent<CanvasGroup>();
        }

        mainCanvasGroup = mainCanvas.GetComponent<CanvasGroup>();
        if (mainCanvasGroup == null)
        {
            mainCanvasGroup = mainCanvas.AddComponent<CanvasGroup>();
        }

        // 처음에는 투명하게 설정
        settingCanvasGroup.alpha = 0f;
        settingCanvas.SetActive(false);

        // 버튼 클릭 시 ToggleSettingCanvas 함수 실행
        settingButton.onClick.AddListener(ToggleSettingCanvas);
    }

    void Update()
    {
        // ESC 키를 누르면 settingCanvas를 비활성화
        if (Input.GetKeyDown(KeyCode.Escape) && settingCanvas.activeSelf)
        {
            StartCoroutine(FadeOut());
        }
    }

    void ToggleSettingCanvas()
    {
        // 현재 상태의 반대로 변경 (비활성화 → 활성화, 활성화 → 비활성화)
        if (settingCanvas.activeSelf)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
    }

    System.Collections.IEnumerator FadeIn()
    {
        isFading = true;
        settingCanvas.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            settingCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            mainCanvasGroup.alpha = Mathf.Lerp(1f, mainCanvasFinalAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        settingCanvasGroup.alpha = 1f;
        mainCanvasGroup.alpha = mainCanvasFinalAlpha;
        isFading = false;
    }

    System.Collections.IEnumerator FadeOut()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            settingCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            mainCanvasGroup.alpha = Mathf.Lerp(mainCanvasFinalAlpha, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        settingCanvasGroup.alpha = 0f;
        mainCanvasGroup.alpha = 1f;
        settingCanvas.SetActive(false);
        isFading = false;
    }
}