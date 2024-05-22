using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float _gameTime = 90; 

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
        _gameTime += time;
        Debug.Log("Time added: " + time);
    }

    public void AddSpeed(float speed)
    {
        //TODO implement speed
    }

    public void AddShield(float shield)
    {
        //TODO
    }
}
