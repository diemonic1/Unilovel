using UnityEngine;

public class CubeOnLevelControl : MonoBehaviour
{
    [SerializeField] private float _levelRotationSensitivity, _levelRotationSensitivityShift;

    private float _currentlevelRotationSensitivity;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;

    private void FixedUpdate()
    {
        if (!pauseMenu.IsPause)
        {
            transform.Rotate(new Vector3(-1, 0, 0), -Input.GetAxis("Vertical") * _currentlevelRotationSensitivity, Space.World);
            transform.Rotate(new Vector3(0, 0, -1), Input.GetAxis("Horizontal") * _currentlevelRotationSensitivity, Space.World);

            if (Input.GetAxis("Shift") != 0)
                _currentlevelRotationSensitivity = _levelRotationSensitivityShift;
            else
                _currentlevelRotationSensitivity = _levelRotationSensitivity;
        }
    }
}
