using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gameTimer;
    [SerializeField] private KatamariPlayer _katamariPlayer;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] List<GameObject> _gameLevels;

    [SerializeField] private List<int> _scoreToWin;
    [SerializeField] private List<int> _scoreForExtraLife;
    
    private int _itemsCollected = 0;
    private int _currentScore = 0;
    private int _currentLevel = 0;
    private int _curentLife = 3;

    [HideInInspector] public static GameManager Instance { get; private set; }

     private void Awake()
    {
          if (Instance == null)
          {
                Instance = this;
          }
          else
          {
                Destroy(gameObject);
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

    public void ColledItem()
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
            _gameLevels[index].SetActive(true);
        }
    }

    public void ResetGame() 
    {         
        _gameTimer.ResetTimer();
        _katamariPlayer.ResetPosition();
        _katamariPlayer.ClearChilren(); //Comment this is you want to keep the dust particles between levels or tries.
        _itemsCollected = 0;
        _currentScore = 0;
        _scoreUI.SetScore(_currentScore, _scoreToWin[_currentLevel], _scoreForExtraLife[_currentLevel]);
        _scoreUI.UpdateLifes(_curentLife);
    }

    private void CheckAddLife()
    {
        if (_currentScore >= _scoreForExtraLife[_currentLevel])
        {
            if (_curentLife < 5)
            {
                _curentLife++;
                _scoreUI.UpdateLifes(_curentLife);
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
                _gameTimer.TimmerRunning(true); // remove this with a game canvas
            }
            else
            {
                //TODO win the game
            }
        }
        else
        {
            _curentLife--;
            if (_curentLife > 0)
            {
                ResetGame();
                _gameTimer.TimmerRunning(true); // remove this with a game canvas
            }
            else
            {
                //TODO lose the game
            }
        }
    }
}
