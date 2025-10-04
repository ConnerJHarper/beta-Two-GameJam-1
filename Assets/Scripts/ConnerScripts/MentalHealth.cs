using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MentalHealth : MonoBehaviour
{
    public static MentalHealth Instance;

    public int stress = 0;
    public int maxStress = 10;

    public Slider stressSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            UpdateStressUI();
        }
    }

    public void ChangeStress(int amount)
    {
        stress += amount;
        stress = Mathf.Clamp(stress, 0, maxStress); // keep stress in 0..maxStress
        UpdateStressUI();
        Debug.Log("Current Stress = " + stress);
    }

    private void UpdateStressUI()
    {
        if (stressSlider == null)
        {
            stressSlider = GameObject.Find("StressSlider")?.GetComponent<Slider>();
        }

        if (stressSlider != null)
        {
            stressSlider.value = (float)stress / maxStress; // normalize 0..1
        }
        else
        {
            Debug.LogWarning("Stress Slider not found in scene: " + SceneManager.GetActiveScene().name);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateStressUI();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        if (stress == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            stress = 0;
        }
    }

}
