using UnityEngine;

public class MainMenuButtonFunctions : MonoBehaviour
{
    [SerializeField] private AudioSource _ClickSound;
    [SerializeField] private GameObject _menu, _exitMenu, _newGameMenu, _loadLevelMenu;

    [Header("Links to instances")]
    [SerializeField] private LocalizationManager localizationManager;
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private MainMenu mainMenu;

    public void changeLanguage()
    {
        _ClickSound.Play();

        switch (mainMenu.getdropdownMenuLanguageValue())
        {
            case 0:
                PlayerPrefs.SetString("Language", "en_US");
                break;
            case 1:
                PlayerPrefs.SetString("Language", "ru_RU");
                break;
        }

        if (localizationManager != null) 
            localizationManager.CurrentLanguage = PlayerPrefs.GetString("Language");
    }

    public void loadLevel(int x)
    {
        _ClickSound.Play();
        mainMenu.CloseMenu();

        PlayerPrefs.SetInt("dial", x - 1);
        PlayerPrefs.SetInt("lvl", x - 1);
        PlayerPrefs.SetInt("progress", (x - 1) * 2);

        transitionToNextScene.continueGame();
    }

    public void newGame()
    {
        _ClickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.newGame();
    }

    public void continueGame()
    {
        _ClickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.continueGame();
    }

    public void exit()
    {
        _ClickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.exitFromGame();
    }

    public void buttonBack()
    {
        _ClickSound.Play();
        _menu.SetActive(true);
        _exitMenu.SetActive(false);
        _newGameMenu.SetActive(false);
        _loadLevelMenu.SetActive(false);
    }

    public void openNewGameMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _newGameMenu.SetActive(true);
    }

    public void openLoadLevelMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _loadLevelMenu.SetActive(true);
    }

    public void openExitMenu()
    {
        _ClickSound.Play();
        _menu.SetActive(false);
        _exitMenu.SetActive(true);
    }
}
