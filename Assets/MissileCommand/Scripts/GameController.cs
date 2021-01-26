using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void OnPlayButtonTapped()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
