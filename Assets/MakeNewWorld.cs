using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject makeNewWorldPopUpCanvas;
    public Button button4_1; // 추후 기능 추가
    public Button button4_2; // 팝업 닫기 버튼

    private Button currentBlankButton; // 현재 Blank 속성을 가진 버튼

    void Start()
    {
        makeNewWorldPopUpCanvas.SetActive(false);
        // 버튼 2, 3 비활성화
        button2.interactable = false;
        button3.interactable = false;

        // 처음 Blank 속성은 버튼1이 가짐
        currentBlankButton = button1;

        // 버튼 이벤트 할당
        button1.onClick.AddListener(() => OnBlankButtonClick(button1, button2));
        button2.onClick.AddListener(() => OnBlankButtonClick(button2, button3));
        button3.onClick.AddListener(() => OnBlankButtonClick(button3, null)); // 버튼3 이후는 이동X

        button4_1.onClick.AddListener(OnButton4_1Click); // 추후 기능 추가 예정
        button4_2.onClick.AddListener(ClosePopUpCanvas);
    }

    void OnBlankButtonClick(Button clickedButton, Button nextButton)
    {
        if (currentBlankButton == clickedButton)
        {
            // MakeNewWorldPopUpCanvas 활성화
            makeNewWorldPopUpCanvas.SetActive(true);
        }
    }

    void ClosePopUpCanvas()
    {
        makeNewWorldPopUpCanvas.SetActive(false);
    }

    public void MoveBlankToNext()
    {
        if (currentBlankButton == button1)
        {
            SetBlank(button2);
        }
        else if (currentBlankButton == button2)
        {
            SetBlank(button3);
        }
    }

    void SetBlank(Button newBlank)
    {
        if (newBlank != null)
        {
            currentBlankButton = newBlank;
            newBlank.interactable = true;
        }
        makeNewWorldPopUpCanvas.SetActive(false);
    }

    void OnButton4_1Click()
    {
        // 추후 기능 추가 예정
        Debug.Log("버튼 4-1 클릭 (추후 기능 추가)");
    }
}
