using UnityEngine;

public class KatamariPlayer : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _force = 10f;

    private Rigidbody _rigidBody;
    private Vector3 _moveDirection;
    private bool _canMove = true;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_canMove)
        {
            GetInput();
            MoveSphere();
        }
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }

    private void GetInput()
    {
        _moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _moveDirection += _playerCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _moveDirection -= _playerCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _moveDirection -= _playerCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _moveDirection += _playerCamera.transform.right;
        }

        _moveDirection.y = 0; // this is used to not apply gravity
        _moveDirection.Normalize();
    }

    private void MoveSphere()
    {
        if(_moveDirection == Vector3.zero)
        {
            _rigidBody.drag = 5f;
        } else
        {
            _rigidBody.drag = 0f;
        }
        _rigidBody.AddForce(_moveDirection * _force);
    }
}
