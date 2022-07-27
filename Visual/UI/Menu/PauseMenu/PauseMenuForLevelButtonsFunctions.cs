using UnityEngine;

public class PauseMenuForLevelButtonsFunctions : PauseMenuButtonsFunctions
{
    [SerializeField] private GameObject _helpWindow;
    [SerializeField] private GameObject _reloadMenu, _skipMenu1, _skipMenu2;

    [Header("Links to instances")]
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    public override void ExitFromGame()
    {
        _clickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.TurnPause();
        transitionToNextScene.ExitFromGame();
    }

    public override void BackButton()
    {
        _clickSound.Play();
        _menu.SetActive(true);
        _exitMenu1.SetActive(false);
        _exitMenu2.SetActive(false);

        _reloadMenu.SetActive(false);
        _skipMenu1.SetActive(false);
        _skipMenu2.SetActive(false);
    }

    public void ToggleHelpWindowVisibility()
    {
        _clickSound.Play();
        _helpWindow.SetActive(!_helpWindow.activeSelf);
    }

    public void OpenReloadLevelMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _reloadMenu.SetActive(true);
    }

    public void ReloadLevel()
    {
        _clickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.TurnPause();
        transitionToNextScene.RestartLevel();
    }

    public void OpenSkipLevelMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _skipMenu1.SetActive(true);
    }

    public void OpenSkipLevelMenu2()
    {
        _clickSound.Play();

        if (PlayerPrefs.GetInt("lvl") != 1)
        {
            SkipLevel();
        }
        else
        {
            _skipMenu1.SetActive(false);
            _skipMenu2.SetActive(true);
        }
    }

    public void SkipLevel()
    {
        _clickSound.Play();
        _helpWindow.SetActive(false);
        pauseMenu.TurnPause();
        playerSpawnAndRespawn.FinishLevel();
    }
}
