using System.Collections;
using UnityEngine;

public class LevelExitPortal : MonoBehaviour
{
    [SerializeField] private Transform[] _exitPortalPositions;
    [SerializeField] private float _stepRotation, _loopDelay;

    private float _currentRotationAxisZ;
    private GameObject _camera;
    private Transform _currentExitPortalPosition;

    [Header("Links to instances")]
    [SerializeField] private LevelSceneBuilder levelSceneBuilder;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("cameraHead");
    }

    private void Start()
    {
        _currentExitPortalPosition = _exitPortalPositions[levelSceneBuilder.CurrentLevel - 1];
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        _currentRotationAxisZ += _stepRotation;

        if (_currentRotationAxisZ == 360)
            _currentRotationAxisZ = 0;

        yield return new WaitForSeconds(_loopDelay);
        StartCoroutine(Loop());
    }

    private void FixedUpdate()
    {
        transform.position = _currentExitPortalPosition.position;

        transform.localEulerAngles = new Vector3(_camera.transform.localEulerAngles.x, _camera.transform.localEulerAngles.y, _camera.transform.localEulerAngles.z + _currentRotationAxisZ);
    }
}
