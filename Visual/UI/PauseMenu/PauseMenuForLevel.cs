using UnityEngine;

public class PauseMenuForLevel : PauseMenu
{
    [SerializeField] private GameObject _helpWindow;

    protected override void checkPressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.H))
            _helpWindow.SetActive(!_helpWindow.activeSelf);

        if (Input.GetKeyDown(KeyCode.Escape))
            turnPause();
    }

    protected override void additionalAction()
    {
        Screen.lockCursor = !Screen.lockCursor;
    }

    public override void showHelpWindow()
    {
        _helpWindow.SetActive(true);
    }
}
