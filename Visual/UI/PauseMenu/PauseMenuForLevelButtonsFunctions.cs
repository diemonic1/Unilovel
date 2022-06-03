using UnityEngine;

public class PauseMenuForLevelButtonsFunctions : PauseMenuButtonsFunctions
{
    [SerializeField] private GameObject _helpWindow;
    [SerializeField] private GameObject _reloadMenu, _skipMenu1, _skipMenu2;

    [Header("Links to instances")]
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    public override void exitGame()
    {
        _ClickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.turnPause();
        transitionToNextScene.exitFromGame();
    }

    public override void backButton()
    {
        _ClickSound.Play();
        _menu.SetActive(true);
        _exitMenu1.SetActive(false);
        _exitMenu2.SetActive(false);

        _reloadMenu.SetActive(false);
        _skipMenu1.SetActive(false);
        _skipMenu2.SetActive(false);
    }

    public void toggleHelpWindowVisibility()
    {
        _ClickSound.Play();
        _helpWindow.SetActive(!_helpWindow.activeSelf);
    }

    public void openReloadLevelMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _reloadMenu.SetActive(true);
    }

    public void reloadLevel()
    {
        _ClickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.turnPause();
        transitionToNextScene.restartLevel();
    }

    public void skipLevelMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _skipMenu1.SetActive(true);
    }

    public void skipLevelMenu2()
    {
        _ClickSound.Play();

        if (PlayerPrefs.GetInt("lvl") != 1)
            skipLevel();
        else
        {
            _skipMenu1.SetActive(false);
            _skipMenu2.SetActive(true);
        }
    }

    public void skipLevel()
    {
        _ClickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.turnPause();
        playerSpawnAndRespawn.finishLevel();
    }
}
