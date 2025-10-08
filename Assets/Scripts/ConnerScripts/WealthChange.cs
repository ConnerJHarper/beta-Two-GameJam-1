using UnityEngine;
using UnityEngine.SceneManagement;
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
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateWealthUI();
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

    public void UpdateWealthUI()
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

    private void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
        UpdateWealthUI();
    }
}

