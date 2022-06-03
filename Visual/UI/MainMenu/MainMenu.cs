using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private bool _testFinalComic;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Animator _menuAnimator1, _menuAnimator2;
    [SerializeField] private Text _masterVolumeText;
    [SerializeField] private Dropdown _dropdownMenuLanguage;

    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private MainMenuUIBuilder mainMenuUIBuilder;
    [SerializeField] private FinalComic finalComic;

    private void Start()
    {
        setStartVolume();

        mainMenuUIBuilder.GetComponent<MainMenuUIBuilder>().buildMenuUI();

        // If this is the first opening of the application, it sets the volume value.
        if (PlayerPrefs.GetInt("firstEnter") == 0)
        {
            PlayerPrefs.SetInt("firstEnter", 1);
            PlayerPrefs.SetFloat("masterVolumePrefs", 100);
        }

        // After completing the game, it shows the final comic strip.
        if (PlayerPrefs.GetInt("EndComics") == 1 || _testFinalComic)
        {
            PlayerPrefs.SetInt("EndComics", 0);
            finalComic.startComic();
        }
        else
            OpenMenu();
    }

    public void dropDownMenuSetLanguage(string currentLanguage) 
    {
        switch (currentLanguage)
        {
            case "en_US":
                _dropdownMenuLanguage.value = 0;
                break;
            case "ru_RU":
                _dropdownMenuLanguage.value = 1;
                break;
        }
    }

    public int getdropdownMenuLanguageValue()
    {
        return _dropdownMenuLanguage.value;
    }

    private void setStartVolume()
    {
        _masterVolumeText.text = "" + (PlayerPrefs.GetInt("masterVolumePrefs")).ToString();
        _masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolumePrefs") / 100;
    }

    private void Update()
    {
        if (transitionToNextScene.IsTransitionNow == false)
            updateVolumeValue();
    }

    private void updateVolumeValue()
    {
        PlayerPrefs.SetInt("masterVolumePrefs", (int)(_masterVolumeSlider.value * 100));
        _masterVolumeText.text = "" + (PlayerPrefs.GetInt("masterVolumePrefs")).ToString();
    }

    public void OpenMenu()
    {
        StartCoroutine(OpenMenuDelay());
    }

    private IEnumerator OpenMenuDelay()
    {
        Screen.lockCursor = false;
        yield return new WaitForSeconds(1.2f);

        _menuAnimator1.speed = 1.5f;
        _menuAnimator2.speed = 1.5f;
        _menuAnimator1.Play("open");
        _menuAnimator2.Play("open2");
    }

    public void CloseMenu()
    {
        _menuAnimator1.Play("close");
        _menuAnimator2.Play("close2");
    }
}
