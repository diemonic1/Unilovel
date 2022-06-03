using UnityEngine;

public class RotateFishAroundTarget : MonoBehaviour
{
    [SerializeField] private float _intensityRotation, _currentRotationAxisX, _currentRotationAxisY, _currentRotationAxisZ;
    [SerializeField] private Vector3 _target;

    private void FixedUpdate()
    {
        transform.RotateAround(_target, new Vector3(_currentRotationAxisX, _currentRotationAxisY, _currentRotationAxisZ), _intensityRotation * Time.deltaTime);
    }
}
