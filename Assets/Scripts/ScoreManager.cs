using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject instructionsScreen;
    
    private int _score;
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _score = 0;
        UpdateScoreText();
        
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText();
    }
}