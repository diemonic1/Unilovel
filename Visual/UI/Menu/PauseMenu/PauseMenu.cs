using UnityEngine;
using UnityEngine.UI;

public abstract class PauseMenu : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Animator _fadePauseAnimator, _menuAnimator1, _menuAnimator2;
    [SerializeField] private Text _masterVolumeText;

    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;

    public bool IsPause { get; private set; }

    public virtual void ShowHelpWindow()
    {
    }

    public void TurnPause()
    {
        _menuAnimator1.speed = 3.5f;
        _menuAnimator2.speed = 3.5f;

        if (IsPause == true)
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

        AdditionalAction();

        IsPause = !IsPause;
    }

    protected virtual void AdditionalAction()
    {
    }

    protected virtual void CheckAdditionalPressedKeys()
    {
    }

    private void Start()
    {
        _masterVolumeText.text = string.Empty + PlayerPrefs.GetInt("masterVolumePrefs").ToString();
        _masterSlider.value = PlayerPrefs.GetInt("masterVolumePrefs") / 100;
    }

    private void Update()
    {
        if (transitionToNextScene.IsTransitionNow == false)
        {
            UpdateVolumeValue();
            CheckPressedKeys();
        }
    }

    private void UpdateVolumeValue()
    {
        PlayerPrefs.SetInt("masterVolumePrefs", (int)(_masterSlider.value * 100));
        _masterVolumeText.text = string.Empty + PlayerPrefs.GetInt("masterVolumePrefs").ToString();
    }

    private void CheckPressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TurnPause();

        CheckAdditionalPressedKeys();
    }
}
