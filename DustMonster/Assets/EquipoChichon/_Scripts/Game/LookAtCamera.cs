using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    private void Update()
    {
        Vector3 targetPosition = _camera.transform.position;
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
}
