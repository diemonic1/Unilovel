using UnityEngine;

public class PauseMenuForLevelButtonsFunctions : PauseMenuButtonsFunctions
{
    [SerializeField] private GameObject _helpWindow;
    [SerializeField] private GameObject _reloadMenu, _skipMenu1, _skipMenu2;

    [Header("Links to instances")]
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    public override void ExitFromGame()
    {
        _helpWindow.SetActive(false);

        base.ExitFromGame();
    }

    public override void BackButton()
    {
        _reloadMenu.SetActive(false);
        _skipMenu1.SetActive(false);
        _skipMenu2.SetActive(false);

        base.BackButton();
    }

    public void ToggleHelpWindowVisibility()
    {
        PlayClickSound();
        _helpWindow.SetActive(!_helpWindow.activeSelf);
    }

    public void OpenReloadLevelMenu()
    {
        PlayClickSound();
        SetMenuActivity(false);
        _reloadMenu.SetActive(true);
    }

    public override void ReloadLevel()
    {
        _helpWindow.SetActive(false);

        base.ReloadLevel();
    }

    public void OpenSkipLevelMenu()
    {
        PlayClickSound();
        SetMenuActivity(false);
        _skipMenu1.SetActive(true);
    }

    public void OpenSkipLevelMenu2()
    {
        PlayClickSound();

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

    public override void SkipLevel()
    {
        _helpWindow.SetActive(false);
        playerSpawnAndRespawn.FinishLevel();
    }
}
