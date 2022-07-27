using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    public void DropDownMenuSetLanguage(string currentLanguage)
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

    public int GetdropdownMenuLanguageValue()
    {
        return _dropdownMenuLanguage.value;
    }

    public void OpenMenu()
    {
        StartCoroutine(OpenMenuDelay());
    }

    public void CloseMenu()
    {
        _menuAnimator1.Play("close");
        _menuAnimator2.Play("close2");
    }

    private void Start()
    {
        SetStartVolume();

        mainMenuUIBuilder.GetComponent<MainMenuUIBuilder>().BuildMenuUI();

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
            finalComic.StartComic();
        }
        else
        {
            OpenMenu();
        }
    }

    private void SetStartVolume()
    {
        _masterVolumeText.text = string.Empty + PlayerPrefs.GetInt("masterVolumePrefs").ToString();
        _masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolumePrefs") / 100;
    }

    private void Update()
    {
        if (transitionToNextScene.IsTransitionNow == false)
            UpdateVolumeValue();
    }

    private void UpdateVolumeValue()
    {
        PlayerPrefs.SetInt("masterVolumePrefs", (int)(_masterVolumeSlider.value * 100));
        _masterVolumeText.text = string.Empty + PlayerPrefs.GetInt("masterVolumePrefs").ToString();
    }

    private IEnumerator OpenMenuDelay()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        yield return new WaitForSeconds(1.2f);

        _menuAnimator1.speed = 1.5f;
        _menuAnimator2.speed = 1.5f;
        _menuAnimator1.Play("open");
        _menuAnimator2.Play("open2");
    }
}
