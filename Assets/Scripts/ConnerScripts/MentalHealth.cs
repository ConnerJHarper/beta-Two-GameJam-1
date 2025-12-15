using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MentalHealth : MonoBehaviour
{
    public static MentalHealth Instance;

    // We will set stress and maximum stress values to public to access in unity inspector 
    public int stress = 100;
    public int maxStress = 100;


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

    private void Start()
    {
        // Update stress UI when game first starts 
        UpdateStressUI();
    }

    public void ChangeStress(int amount)
    {
        // We will add the amount and stress together then put the output back into the stress value 
        stress += amount;
        stress = Mathf.Clamp(stress, 0, maxStress);
        UpdateStressUI();
    }

    private void UpdateStressUI()
    {
        if (stressSlider == null)
        {
            // We will find stress slider in order to change this within this script
            stressSlider = GameObject.Find("StressSlider")?.GetComponent<Slider>();
        }


        if (stressSlider != null)
        {
            stressSlider.value = ((float)stress / maxStress);
        }
        else
        {
           // We will leave this blank 
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
        // If stress equals 0 we will move on to the end screen 
        if (stress == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            stress = maxStress;
        }
    }

}
