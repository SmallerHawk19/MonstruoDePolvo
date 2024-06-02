using UnityEngine;

public class BallFollower : MonoBehaviour
{
    [SerializeField] private GameObject _ball;

    private void Update()
    {
        transform.position = _ball.transform.position;
    }
}
