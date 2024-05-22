using UnityEngine;

public class Spinner : MonoBehaviour
{
   [SerializeField] private float _rotationSpeed = 100f;
   [SerializeField] private bool _moveUpAndDown = false;
   [SerializeField] private float _moveSpeed = 0.1f;
   [SerializeField] private float _moveDistance = 0.1f;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
         RotateObject();
         MoveObjectUpAndDown();
    }

    private void MoveObjectUpAndDown()
    {
        if (_moveUpAndDown)
        {
            transform.position = new Vector3(transform.position.x, _startPosition.y + Mathf.PingPong(Time.time * _moveSpeed, _moveDistance), transform.position.z);
        }
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
