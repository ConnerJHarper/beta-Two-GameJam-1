using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WealthChange : MonoBehaviour
{
    public static WealthChange Instance;

    public int wealth = 100;        
    public Text wealthText;      

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
        UpdateWealthUI();
    }

    public void AddWealth(int amount)
    {
        // We will add the amount of wealth to original wealth then add that back into the wealth value to display on UI. 
        wealth += amount;
        UpdateWealthUI();
    }

    public void UpdateWealthUI()
    {
        // Search for the wealth value text component 
        wealthText = GameObject.Find("WealthValue")?.GetComponent<Text>();
        if (wealthText != null)
        {
            // We will add a pound symbol to start of the wealth value. 
            wealthText.text = "£" + wealth.ToString();
        }
        else
        {
            // This will tell us that the wealth text is NULL
            Debug.LogError("Wealth Text is NULL");
        }
    }

    private void OnDestroy()
    {

        if (Instance == this)
        SceneManager.sceneLoaded -= OnSceneLoaded;
        UpdateWealthUI();
    }

    private void Update()
    {
        // If wealth = 0 then we will 
        if (wealth == 0)
        {
            SceneManager.LoadScene("End Scene");
            Destroy(gameObject);
            
        }
    }
}

