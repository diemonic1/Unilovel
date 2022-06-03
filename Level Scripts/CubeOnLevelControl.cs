using UnityEngine;

public class CubeOnLevelControl : MonoBehaviour
{
    [SerializeField] private float levelRotationSensitivity, levelRotationSensitivityShift;

    private float CurrentlevelRotationSensitivity;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;

    private void FixedUpdate()
    {
        if (!pauseMenu.isPause)
        {
            transform.Rotate(new Vector3(-1, 0, 0), (-Input.GetAxis("Vertical") * CurrentlevelRotationSensitivity), Space.World);
            transform.Rotate(new Vector3(0, 0, -1), (Input.GetAxis("Horizontal") * CurrentlevelRotationSensitivity), Space.World);

            if (Input.GetAxis("Shift") != 0)
                CurrentlevelRotationSensitivity = levelRotationSensitivityShift;
            else
                CurrentlevelRotationSensitivity = levelRotationSensitivity;
        }
    }
}
