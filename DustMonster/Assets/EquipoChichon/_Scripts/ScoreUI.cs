using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winCurrentScore;
    [SerializeField] private TextMeshProUGUI _winScore;
    [SerializeField] private TextMeshProUGUI _lifeCurrentScore;
    [SerializeField] private TextMeshProUGUI _lifeScore;
    [SerializeField] private List<GameObject> _lifes;

    private int _currentScore = 0;
    private int _scoreToWin = 0;
    private int _scoreForExtraLife = 0;

    public void SetScore(int currentScore, int scoreToWin, int scoreForExtraLife)
    {
        _currentScore = currentScore;
        _scoreToWin = scoreToWin;
        _scoreForExtraLife = scoreForExtraLife;

        _winCurrentScore.text = _currentScore.ToString();
        _winScore.text = _scoreToWin.ToString();
        _lifeCurrentScore.text = _currentScore.ToString();
        _lifeScore.text = _scoreForExtraLife.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _winCurrentScore.text = _currentScore.ToString();
        _lifeCurrentScore.text = _currentScore.ToString();
    }

    public void UpdateLifes(int currentLifes)
    {
        for (int i = 0; i < _lifes.Count; i++)
        {
            _lifes[i].SetActive(i < currentLifes);
        }
    }
}
