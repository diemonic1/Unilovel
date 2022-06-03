using UnityEngine.UI;
using UnityEngine;

public abstract class PauseMenu : MonoBehaviour
{
    public bool isPause { get; private set; }

    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Animator _fadePauseAnimator, _menuAnimator1, _menuAnimator2;
    [SerializeField] private Text _masterVolumeText;

    [Header("Links to instances")]
    [SerializeField] protected LocalizationManager localizationManager;
    [SerializeField] protected TransitionToNextScene transitionToNextScene;

    private void Start()
    {
        _masterVolumeText.text = "" + (PlayerPrefs.GetInt("masterVolumePrefs")).ToString();
        _masterSlider.value = PlayerPrefs.GetInt("masterVolumePrefs") / 100;
    }

    private void Update()
    {
        if (transitionToNextScene.IsTransitionNow == false)
        {
            updateVolumeValue();
            checkPressedKeys();
        }
    }

    private void updateVolumeValue() 
    {
        PlayerPrefs.SetInt("masterVolumePrefs", (int)(_masterSlider.value * 100));
        _masterVolumeText.text = "" + (PlayerPrefs.GetInt("masterVolumePrefs")).ToString();
    }

    protected virtual void checkPressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            turnPause();
    }

    public void turnPause() 
    {
        _menuAnimator1.speed = 3.5f;
        _menuAnimator2.speed = 3.5f;

        if (isPause == true)
        {
            _fadePauseAnimator.Play("outPause");
            _menuAnimator1.Play("close");
            _menuAnimator2.Play("close2");
        }
        else
        {
            _fadePauseAnimator.Play("inPause");
            _menuAnimator1.Play("open");
            _menuAnimator2.Play("open2");
        }

        additionalAction();

        isPause = !isPause;
    }

    protected virtual void additionalAction() { }

    public virtual void showHelpWindow() { }
}
