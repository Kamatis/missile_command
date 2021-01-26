using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Spawner _spawner;

    public void OnPlayButtonTapped()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        _spawner.StopSpawning();
    }

    public static GameController Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
