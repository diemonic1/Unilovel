using UnityEngine;

public abstract class PauseMenuButtonsFunctions : MonoBehaviour, IMenuButtonsFunctions
{
    [SerializeField] protected AudioSource _clickSound;
    [SerializeField] protected GameObject _menu, _exitMenu1, _exitMenu2;

    [Header("Links to instances")]
    [SerializeField] protected TransitionToNextScene transitionToNextScene;
    [SerializeField] protected PauseMenu pauseMenu;

    public void ContinueGame()
    {
        _clickSound.Play();
        pauseMenu.TurnPause();
    }

    public void OpenExitInMainMenuMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _exitMenu1.SetActive(true);
    }

    public void ExitInMainMenu()
    {
        _clickSound.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.TurnPause();
        transitionToNextScene.ExitInMenu();
    }

    public void OpenExitFromGameMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _exitMenu2.SetActive(true);
    }

    public virtual void ExitFromGame()
    {
    }

    public virtual void BackButton()
    {
    }
}
