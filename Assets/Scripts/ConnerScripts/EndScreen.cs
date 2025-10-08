using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject stressCanvas = GameObject.Find("StressCanvas");
        if (stressCanvas != null )
        {
            Destroy(stressCanvas);
        }
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
