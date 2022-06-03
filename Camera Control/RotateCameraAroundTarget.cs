using UnityEngine;

public class RotateCameraAroundTarget : MonoBehaviour
{
    [SerializeField] private Vector3 _offset, _target;
    [SerializeField] private float _maxRotationAxisY, _sensitivityRotation, _sensitivityZoom, _maximumZoom, _minimumZoom, _divisor1, _divisor2;

    private float _currentRotationAxisX = -37.5f, _currentRotationAxisY = -18, _stepZoom, _currentZoom = -7.5f;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;

    private void Start()
    {
        transform.position = _offset + _target;
    }

    private void Update()
    {
        if (!pauseMenu.isPause)
        {
            updateZoom();

            rotateWithMouseButton();

            transform.localEulerAngles = new Vector3(-_currentRotationAxisY, _currentRotationAxisX, 0);
            transform.position = transform.localRotation * _offset + _target;
        }
    }

    private void updateZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _currentZoom < -_minimumZoom)
            _currentZoom = _offset.z + _sensitivityZoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && _currentZoom > -_maximumZoom)
            _currentZoom = _offset.z - _sensitivityZoom;

        if (Mathf.Abs(_offset.z - _currentZoom) > 0.0001f)
        {
            _stepZoom = Mathf.Abs(_offset.z - _currentZoom) / _divisor1;

            if (_offset.z < _currentZoom)
                _offset.z += _stepZoom;
            else
                _offset.z -= _stepZoom;

            _stepZoom -= Mathf.Abs(_offset.z - _currentZoom) / _divisor2;
        }

        _offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(_maximumZoom), -Mathf.Abs(_minimumZoom));
    }

    private void rotateWithMouseButton()
    {
        if (Input.GetButton("Fire1"))
        {
            _currentRotationAxisY += Input.GetAxis("Mouse Y") * _sensitivityRotation;
            _currentRotationAxisX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivityRotation;
        }

        _currentRotationAxisY = Mathf.Clamp(_currentRotationAxisY, -_maxRotationAxisY, _maxRotationAxisY);
    }
}
