using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gameTimer;
    [SerializeField] private KatamariPlayer _katamariPlayer;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private List<GameObject> _gameLevels = new List<GameObject>();
    [SerializeField] private List<AudioSource> _gameMusicByLevel = new List<AudioSource>();

    [SerializeField] private List<int> _scoreToWin = new List<int>();

    [SerializeField] private List<GameObject> _levelCanvas = new List<GameObject>();
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;
    [SerializeField] private GameObject _resetCanvas;

    [Range(0,3)]
    [SerializeField] private int _difficulty = 1;

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
        UpdateDifficulty(_difficulty);
    }

    public void AddTime(float time)
    {
        _gameTimer.AddTime(time);
    }

    public void AddSpeed(float speed)
    {
        _katamariPlayer.AddSpeed(speed);
    }

    public void AddScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _scoreUI.AddScore(scoreToAdd);
    }

    public void AddShield(float shieldToAdd)
    {
        //TODO
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
            ResetMusic(index);
            _levelCanvas[index].SetActive(true);
            Cursor.lockState = CursorLockMode.None;
    }

    private void RetryLevel()
    {
        _katamariPlayer.SetCanMove(false);
        _katamariPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _katamariPlayer.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        _resetCanvas.SetActive(true);
        Invoke("ResetGame", 3f);
        Invoke("StartGame", 3.5f);
    }

    public void ResetGame() 
    {    
        _resetCanvas.SetActive(false);
        _gameTimer.ResetTimer();
        _katamariPlayer.ResetPosition();
        _katamariPlayer.SetCanMove(false);
        _katamariPlayer.ClearChildren(); //Comment this is you want to keep the dust particles between levels or tries.
        _itemsCollected = 0;
        _currentScore = 0;
        UpdateDifficulty(_difficulty);
        _scoreUI.UpdateLifes(_currentLife);
    }

    public void StartGame()
    {
        _gameTimer.TimmerRunning(true);
        _katamariPlayer.SetCanMove(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateDifficulty(int difficulty)
    {
        _difficulty = difficulty;

        if(_difficulty > 3) _difficulty = 3;
        if(_difficulty < 0) _difficulty = 0;

        CalculateDifficultyScore();
    }

    private void CheckAddLife()
    {
        if (_currentScore >= ScoreForExtraLife(_difficulty))
        {
            if (_currentLife < 5)
            {
                _currentLife++;
                _scoreUI.UpdateLifes(_currentLife);
            }
        }
    }

    private void UpdateScore(int scoreToWin, int scoreForExtraLife)
    {
        _scoreUI.SetScore(_currentScore, scoreToWin, scoreForExtraLife);
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
                Cursor.lockState = CursorLockMode.None;
                ResetMusic(_currentLevel);
            }
        }
        else
        {
            _currentLife--;
            if (_currentLife > 0)
            {
               RetryLevel();
            }
            else
            {
                _loseCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                ResetMusic(_gameMusicByLevel.Count -1);
            }
        }
    }

    private void CalculateDifficultyScore()
    {
        UpdateScore(ScoreToWin(_difficulty), ScoreForExtraLife(_difficulty));
    }

    private int ScoreToWin(int difficulty)
    {
        switch (_difficulty)
        {
            case 3:
                return RoundScore(_scoreToWin[_currentLevel]);
            case 2:
                return RoundScore(_scoreToWin[_currentLevel] * 0.80f);
            case 1:
                return RoundScore(_scoreToWin[_currentLevel] * 0.60f);
            case 0:
                return RoundScore(_scoreToWin[_currentLevel] * 0.40f);
            default:
                return 0;
        }
    }

    private int ScoreForExtraLife(int difficulty)
    {
        switch (_difficulty)
        {
            case 3:
                return RoundScore(_scoreToWin[_currentLevel] * 1.10f);
            case 2:
                return RoundScore(_scoreToWin[_currentLevel] * 0.90f);
            case 1:
                return RoundScore(_scoreToWin[_currentLevel] * 0.70f);
            case 0:
                return RoundScore(_scoreToWin[_currentLevel] * 0.50f);
            default:
                return 0;
                
        }
    }

    private int RoundScore(float score)
    {
        int newScore = Mathf.RoundToInt(score);
        while(newScore % 5 != 0)
        {
            newScore++;
        }
        return newScore;
    }

    private void ResetMusic(int index)
    {
        for(int i = 0; i < _gameMusicByLevel.Count; i++)
        {
            _gameMusicByLevel[i].Stop();
        }

        _gameMusicByLevel[index].Play();
    }
}
