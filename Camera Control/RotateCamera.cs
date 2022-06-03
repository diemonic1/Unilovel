using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivityOfRotation, _verticalAmplitude, _horizontalAmplitude;

    private float _currentRotationAxisX, _currentRotationAxisY;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;

    private void Update()
    {
        if (Input.GetButton("Fire2") && !pauseMenu.isPause)
        {
            _currentRotationAxisX -= Input.GetAxis("Mouse Y") * _sensitivityOfRotation;
            _currentRotationAxisX = Mathf.Clamp(_currentRotationAxisX, -_verticalAmplitude, _verticalAmplitude);

            _currentRotationAxisY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivityOfRotation;

            if (_currentRotationAxisY > _horizontalAmplitude && _currentRotationAxisY < 180)
                _currentRotationAxisY = _horizontalAmplitude;

            if (_currentRotationAxisY > 180 && _currentRotationAxisY < 360 - _horizontalAmplitude)
                _currentRotationAxisY = 360 - _horizontalAmplitude;

            transform.localEulerAngles = new Vector3(_currentRotationAxisX, _currentRotationAxisY, 0);
        }
    }
}