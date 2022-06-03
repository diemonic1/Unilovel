using System.Collections;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] private float _intensityMove, _intensityRotate, _movementAmplitude, _rotationAmplitudeAxisX, _rotationAmplitudeAxisY, _rotationAmplitudeAxisZ;

    private float _randomRotationStepAxisX, _randomRotationStepAxisY, _randomRotationStepAxisZ;

    private Vector3 _nextSwayVector;
    private Vector3 _nextSwayPosition;
    private Vector3 _startLocalPosition;

    private void Start()
    {
        _nextSwayVector = Vector3.up * _movementAmplitude;
        _nextSwayPosition = transform.localPosition + _nextSwayVector;
        _startLocalPosition = transform.localPosition;

        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        yield return new WaitForSeconds(4f);

        _randomRotationStepAxisX = Random.Range(-_rotationAmplitudeAxisX, _rotationAmplitudeAxisX);
        _randomRotationStepAxisY = Random.Range(-_rotationAmplitudeAxisY, _rotationAmplitudeAxisY);
        _randomRotationStepAxisZ = Random.Range(-_rotationAmplitudeAxisZ, _rotationAmplitudeAxisZ);
        
        StartCoroutine(loop());
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _nextSwayPosition, _intensityMove * Time.deltaTime);
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x + _randomRotationStepAxisX, transform.localEulerAngles.y + _randomRotationStepAxisY, transform.localEulerAngles.z + _randomRotationStepAxisZ), _intensityRotate * Time.deltaTime);

        if (Mathf.Abs(transform.localEulerAngles.x) > 5)
            _randomRotationStepAxisX = -_randomRotationStepAxisX;

        if (Mathf.Abs(transform.localEulerAngles.y) > 5)
            _randomRotationStepAxisY = -_randomRotationStepAxisY;

        if (Mathf.Abs(transform.localEulerAngles.z) > 5)
            _randomRotationStepAxisZ = -_randomRotationStepAxisZ;

        if (Vector3.SqrMagnitude(transform.localPosition - _nextSwayPosition) < 0.01f)
        {
            _nextSwayVector = -_nextSwayVector;

            _nextSwayPosition = _startLocalPosition + _nextSwayVector;
        }
    }
}