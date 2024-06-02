using UnityEngine;

public class MateoController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isWalking = false;
    private bool _currentState = false;

    private void Update()
    {
        GetInput();
        SetAnim();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
    }

    private void SetAnim()
    {
        if(_currentState == _isWalking) return;

        if (_isWalking)
        {
            _animator.SetBool("IsWalking", true);
            _animator.speed = 2;
            _currentState = true;
        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _animator.speed = 1f;
            _currentState = false;
        }
    }
}
