using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private GameObject _gameOverObject;
    [SerializeField]
    private GameObject _inputObject;

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
        _gameOverObject.SetActive(true);
        _inputObject.SetActive(false);
    }

    public static GameController Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
