using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonBehaviour : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Day 1");
    }

}

    

