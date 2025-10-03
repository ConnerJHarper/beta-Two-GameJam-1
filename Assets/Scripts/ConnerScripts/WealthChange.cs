using UnityEngine;
using UnityEngine.UI;

public class WealthChange : MonoBehaviour
{
    public static WealthChange Instance;

    public int wealth = 0;        // starting wealth (editable in Inspector)
    public Text wealthText;       // drag your UI Text here in Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // optional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateWealthUI(); // show the starting wealth on UI right away
    }

    public void AddWealth(int amount)
    {
        wealth += amount;
        UpdateWealthUI();
        Debug.Log("TotalWealth = " + wealth);
    }

    private void UpdateWealthUI()
    {
        // Try to find the Text component automatically after scene loads
        wealthText = GameObject.Find("WealthValue")?.GetComponent<Text>();
        if (wealthText != null)
        {
            wealthText.text = "£" + wealth.ToString();
        }
        else
        {
            Debug.LogError("Wealth Text is missing in the scene!");
        }
    }
}

