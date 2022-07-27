using UnityEngine;

public class PauseMenuForLevel : PauseMenu
{
    [SerializeField] private GameObject _helpWindow;

    public override void ShowHelpWindow()
    {
        _helpWindow.SetActive(true);
    }

    protected override void CheckAdditionalPressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.H))
            _helpWindow.SetActive(!_helpWindow.activeSelf);
    }

    protected override void AdditionalAction()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
