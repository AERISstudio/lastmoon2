using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText; // UI Text to display money
    private float moneyAmount = 0f;
    private float moneyPerSecond = 1f / 1f; // 1 dollar per hour

    void Start()
    {
        // Initialize the money display
        UpdateMoneyText();
    }

    void Update()
    {
        // Increase money amount over time
        moneyAmount += moneyPerSecond * Time.deltaTime;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        // Update the UI text with the current money amount
        moneyText.text = "Money: $" + moneyAmount.ToString("F2");
    }
}