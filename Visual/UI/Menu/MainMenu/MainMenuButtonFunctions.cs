using UnityEngine;

public class MainMenuButtonFunctions : MonoBehaviour, IMenuButtonsFunctions
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private GameObject _menu, _exitMenu, _newGameMenu, _loadLevelMenu;

    [Header("Links to instances")]
    [SerializeField] private LocalizationManager localizationManager;
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private MainMenu mainMenu;

    public void ÑhangeLanguage()
    {
        _clickSound.Play();

        switch (mainMenu.GetdropdownMenuLanguageValue())
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

    public void LoadLevel(int x)
    {
        _clickSound.Play();
        mainMenu.CloseMenu();

        PlayerPrefs.SetInt("dial", x - 1);
        PlayerPrefs.SetInt("lvl", x - 1);
        PlayerPrefs.SetInt("progress", (x - 1) * 2);

        transitionToNextScene.ContinueGame();
    }

    public void StartNewGame()
    {
        _clickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.StartNewGame();
    }

    public void ContinueGame()
    {
        _clickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.ContinueGame();
    }

    public void ExitFromGame()
    {
        _clickSound.Play();
        mainMenu.CloseMenu();
        transitionToNextScene.ExitFromGame();
    }

    public void BackButton()
    {
        _clickSound.Play();
        _menu.SetActive(true);
        _exitMenu.SetActive(false);
        _newGameMenu.SetActive(false);
        _loadLevelMenu.SetActive(false);
    }

    public void OpenNewGameMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _newGameMenu.SetActive(true);
    }

    public void OpenLoadLevelMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _loadLevelMenu.SetActive(true);
    }

    public void OpenExitFromGameMenu()
    {
        _clickSound.Play();
        _menu.SetActive(false);
        _exitMenu.SetActive(true);
    }
}
