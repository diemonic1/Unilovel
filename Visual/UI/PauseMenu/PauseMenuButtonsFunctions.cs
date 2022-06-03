using UnityEngine;

public abstract class PauseMenuButtonsFunctions : MonoBehaviour
{
    [SerializeField] protected AudioSource _ClickSound;
    [SerializeField] protected GameObject _menu, _exitMenu1, _exitMenu2;

    [Header("Links to instances")]
    [SerializeField] protected TransitionToNextScene transitionToNextScene;
    [SerializeField] protected PauseMenu pauseMenu;

    public void continueGame()
    {
        _ClickSound.Play();
        pauseMenu.turnPause();
    }

    public void exitInMainMenuMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _exitMenu1.SetActive(true);
    }

    public void exitInMainMenu()
    {
        _ClickSound.Play();
        Screen.lockCursor = true;
        pauseMenu.turnPause();
        transitionToNextScene.exitInMenu();
    }

    public void exitGameMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _exitMenu2.SetActive(true);
    }

    public virtual void exitGame() { }

    public virtual void backButton() { }
}
