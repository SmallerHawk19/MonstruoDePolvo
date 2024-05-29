using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gameTimer;
    [SerializeField] private KatamariPlayer _katamariPlayer;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private List<GameObject> _gameLevels;

    [SerializeField] private List<int> _scoreToWin;
    [SerializeField] private List<int> _scoreForExtraLife;

    [SerializeField] private List<GameObject> _levelCanvas;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;
    
    private int _itemsCollected = 0;
    private int _currentScore = 0;
    private int _currentLevel = 0;
    private int _currentLife = 3;

    [HideInInspector] public static GameManager Instance { get; private set; }

     private void Awake()
    {
          if (Instance == null)
          {
                Instance = this;
          }
          else
          {
                Destroy(this.gameObject);
          }
     }

    private void Start()
    {
        _scoreUI.SetScore(_currentScore, _scoreToWin[_currentLevel], _scoreForExtraLife[_currentLevel]);
    }

    public void AddTime(float time)
    {
        _gameTimer.AddTime(time);
    }

    public void AddSpeed(float speed)
    {
        _katamariPlayer.AddSpeed(speed);
    }

    public void AddShield(float shield)
    {
        //TODO
    }

    public void AddScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _scoreUI.AddScore(scoreToAdd);
    }

    public void CollectedItem()
    {
        _itemsCollected++;
    }

    public void TimerFinished()
    {
        CheckAddLife();
        CheckGameConditions();
    }

    public void ChangeLevel(int index)
    {
        for (int i = 0; i < _gameLevels.Count; i++)
        {
            _gameLevels[i].SetActive(false);
        }
            _gameLevels[index].SetActive(true);
            _levelCanvas[index].SetActive(true);
    }

    public void ResetGame() 
    {         
        _gameTimer.ResetTimer();
        _katamariPlayer.ResetPosition();
        _katamariPlayer.SetCanMove(false);
        _katamariPlayer.ClearChildren(); //Comment this is you want to keep the dust particles between levels or tries.
        _itemsCollected = 0;
        _currentScore = 0;
        _scoreUI.SetScore(_currentScore, _scoreToWin[_currentLevel], _scoreForExtraLife[_currentLevel]);
        _scoreUI.UpdateLifes(_currentLife);
    }

    public void StartGame()
    {
        _gameTimer.TimmerRunning(true);
        _katamariPlayer.SetCanMove(true);
    }

    private void CheckAddLife()
    {
        if (_currentScore >= _scoreForExtraLife[_currentLevel])
        {
            if (_currentLife < 5)
            {
                _currentLife++;
                _scoreUI.UpdateLifes(_currentLife);
            }
        }
    }

    private void CheckGameConditions()
    {
        if (_currentScore >= _scoreToWin[_currentLevel])
        {
            _currentLevel++;
            if (_currentLevel < _gameLevels.Count)
            {
                ChangeLevel(_currentLevel);
                ResetGame();
            }
            else
            {
                _winCanvas.SetActive(true);
            }
        }
        else
        {
            _currentLife--;
            if (_currentLife > 0)
            {
                ChangeLevel(_currentLevel);
                ResetGame();
            }
            else
            {
                _loseCanvas.SetActive(true);
            }
        }
    }
}
