using UnityEngine;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    public GameObject RealQQCanvas;
    public GameObject mainCanvas; // 메인 캔버스
    public Button QuitButton;
    public Button YesButton;
    public Button NoButton;
    public float fadeDuration = 1.5f; // 페이드 인/아웃 지속 시간
    private float mainCanvasFinalAlpha = 0.2f; // 20% opacity

    private CanvasGroup canvasGroup;
    private CanvasGroup mainCanvasGroup;
    private bool isFading = false;

    void Start()
    {
        // 대상 오브젝트에서 CanvasGroup 가져오기, 없으면 추가
        canvasGroup = RealQQCanvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = RealQQCanvas.AddComponent<CanvasGroup>();
        }

        mainCanvasGroup = mainCanvas.GetComponent<CanvasGroup>();
        if (mainCanvasGroup == null)
        {
            mainCanvasGroup = mainCanvas.AddComponent<CanvasGroup>();
        }

        // 처음에는 투명하게 설정
        canvasGroup.alpha = 0f;
        RealQQCanvas.SetActive(false);

        if (QuitButton != null)
            QuitButton.onClick.AddListener(ShowQuitCanvas);

        if (YesButton != null)
            YesButton.onClick.AddListener(QuitGame);

        if (NoButton != null)
            NoButton.onClick.AddListener(CancelQuit);
    }

    void Update()
    {
        // ESC 키를 누르면 RealQQCanvas를 비활성화
        if (Input.GetKeyDown(KeyCode.Escape) && RealQQCanvas.activeSelf)
        {
            StartCoroutine(FadeOut());
        }
    }

    void ShowQuitCanvas()
    {
        if (RealQQCanvas != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    void CancelQuit()
    {
        if (RealQQCanvas != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    System.Collections.IEnumerator FadeIn()
    {
        isFading = true;
        RealQQCanvas.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            mainCanvasGroup.alpha = Mathf.Lerp(1f, mainCanvasFinalAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
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
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            mainCanvasGroup.alpha = Mathf.Lerp(mainCanvasFinalAlpha, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        mainCanvasGroup.alpha = 1f;
        RealQQCanvas.SetActive(false);
        isFading = false;
    }
}