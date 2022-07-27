using UnityEngine;

public class PauseMenuButtonsFunctions : MonoBehaviour, IMenuButtonsFunctions
{
    [SerializeField] private GameObject _menu, _exitMenu1, _exitMenu2;
    [SerializeField] private AudioSource _clickSound;

    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private PauseMenu pauseMenu;

    public void ContinueGame()
    {
        PlayClickSound();
        pauseMenu.TurnPause();
    }

    public void OpenExitInMainMenuMenu()
    {
        PlayClickSound();
        SetMenuActivity(false);
        _exitMenu1.SetActive(true);
    }

    public void ExitInMainMenu()
    {
        PlayClickSound();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.TurnPause();
        transitionToNextScene.ExitInMenu();
    }

    public void OpenExitFromGameMenu()
    {
        PlayClickSound();
        SetMenuActivity(false);
        _exitMenu2.SetActive(true);
    }

    public virtual void ExitFromGame()
    {
        PlayClickSound();
        pauseMenu.TurnPause();
        transitionToNextScene.ExitFromGame();
    }

    public virtual void BackButton()
    {
        PlayClickSound();
        SetMenuActivity(true);
        TurnOffAllExitMenu();
    }

    public virtual void ReloadLevel()
    {
        PlayClickSound();
        pauseMenu.TurnPause();
        transitionToNextScene.RestartLevel();
    }

    public virtual void SkipLevel()
    {
        PlayClickSound();
        pauseMenu.TurnPause();
    }

    protected void PlayClickSound()
    {
        _clickSound.Play();
    }

    protected void SetMenuActivity(bool parametr)
    {
        _menu.SetActive(parametr);
    }

    protected void TurnOffAllExitMenu()
    {
        _exitMenu1.SetActive(false);
        _exitMenu2.SetActive(false);
    }
}
