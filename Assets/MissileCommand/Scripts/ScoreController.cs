using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text scoreText;

    private int _currentPoints;
    private int _highScore;

    private void Start()
    {
        CurrentPoints = 0;
    }

    public int CurrentPoints
    {
        get
        {
            return _currentPoints;
        }

        set
        {
            _currentPoints = value;
            scoreText.text = $"{_currentPoints}";
        }
    }

    public static ScoreController Instance;
    private void Awake()
    {
        Instance = this;
    }
}
