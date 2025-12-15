using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    // Very simple - if restart button is pressed the first scene will be launched
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
