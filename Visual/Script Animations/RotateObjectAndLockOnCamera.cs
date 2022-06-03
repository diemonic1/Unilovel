using UnityEngine;

public class RotateObjectAndLockOnCamera : MonoBehaviour
{
    private float _zRotationRatio = -0.6f;

    private GameObject _camera;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("cameraHead");
    }

    private void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(_camera.transform.localEulerAngles.x, _camera.transform.localEulerAngles.y, _camera.transform.localEulerAngles.z + _zRotationRatio);
    }
}
