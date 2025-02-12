using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText; // UI Text to display money
    public GameObject building; // The building object to change color
    public Button activateButton; // UI Button to activate the building
    private float moneyAmount = 0f;
    private float moneyPerSecond = 1f / 1f; // 1 dollar per hour
    private bool buildingActivated = false;

    void Start()
    {
        // Initialize the money display
        UpdateMoneyText();
        // Set the building to red color initially
        building.GetComponent<Renderer>().material.color = Color.red;
        // Add listener to the button
        activateButton.onClick.AddListener(OnActivateButtonClick);
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

    void OnActivateButtonClick()
    {
        // Check if money amount is greater than or equal to 10 and building is not activated
        if (moneyAmount >= 10f && !buildingActivated)
        {
            ActivateBuilding();
        }
    }

    void ActivateBuilding()
    {
        // Deduct 10 dollars from money amount
        moneyAmount -= 10f;
        // Change the building color to green
        building.GetComponent<Renderer>().material.color = Color.green;
        // Increase money per second to 11 dollars per second
        moneyPerSecond = 11f / 1f;
        buildingActivated = true;
    }
}