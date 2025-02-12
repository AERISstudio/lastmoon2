using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText; // UI Text to display money
    public Text woodText; // UI Text to display wood
    public GameObject building; // The building object to change color
    public Button activateButton; // UI Button to activate the building
    public Button buyWoodBuildingButton; // UI Button to buy the wood building
    private float moneyAmount = 0f;
    private float moneyPerSecond = 1f / 1f; // 1 dollar per hour
    private bool buildingActivated = false;
    private bool woodBuildingActivated = false;
    private int woodAmount = 0;
    private float woodTimer = 0f;
    private float woodInterval = 5f; // 5 seconds to get one wood

    void Start()
    {
        // Initialize the money and wood display
        UpdateMoneyText();
        UpdateWoodText();
        // Set the building to red color initially
        building.GetComponent<Renderer>().material.color = Color.red;
        // Add listeners to the buttons
        activateButton.onClick.AddListener(OnActivateButtonClick);
        buyWoodBuildingButton.onClick.AddListener(OnBuyWoodBuildingButtonClick);
    }

    void Update()
    {
        // Increase money amount over time
        moneyAmount += moneyPerSecond * Time.deltaTime;
        UpdateMoneyText();

        // Increase wood amount over time if wood building is activated
        if (woodBuildingActivated)
        {
            woodTimer += Time.deltaTime;
            if (woodTimer >= woodInterval)
            {
                woodAmount++;
                woodTimer = 0f;
                UpdateWoodText();
            }
        }
    }

    void UpdateMoneyText()
    {
        // Update the UI text with the current money amount
        moneyText.text = "Money: $" + moneyAmount.ToString("F2");
    }

    void UpdateWoodText()
    {
        // Update the UI text with the current wood amount
        woodText.text = "Wood: " + woodAmount;
    }

    void OnActivateButtonClick()
    {
        // Check if money amount is greater than or equal to 10 and building is not activated
        if (moneyAmount >= 10f && !buildingActivated)
        {
            ActivateBuilding();
        }
    }

    void OnBuyWoodBuildingButtonClick()
    {
        // Check if money amount is greater than or equal to 100 and wood building is not activated
        if (moneyAmount >= 100f && !woodBuildingActivated)
        {
            BuyWoodBuilding();
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

    void BuyWoodBuilding()
    {
        // Deduct 100 dollars from money amount
        moneyAmount -= 100f;
        // Activate wood building
        woodBuildingActivated = true;
        UpdateMoneyText();
    }
}