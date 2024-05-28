using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gameTimer;
    [SerializeField] private KatamariPlayer _katamariPlayer;
    [SerializeField] List<GameObject> _gameLevels;
    
    private int _itemsCollected = 0;
    private int _currentScore = 0;

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
    }

    public void ColledItem()
    {
        _itemsCollected++;
    }

    public void TimerFinished()
    {
        //TODO
    }

    public void ChangeScene(int index)
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
        _itemsCollected = 0;
        _currentScore = 0;
    }
}
