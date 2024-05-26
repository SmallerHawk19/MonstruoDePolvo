using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gameTimer;
    [SerializeField] private KatamariPlayer _katamariPlayer;
    
    private int _itemsCollected = 0;

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

    public void ColledItem()
    {
        _itemsCollected++;
    }
}
