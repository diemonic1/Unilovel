using UnityEngine;

public class DialogueAdditionalActions : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private GameObject _skipPhraseButton, _dots;

    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;

    public void PlayJumpAnimation()
    {
        _characterAnimator.Play("jump");
    }

    public void TurnOnLevelScene()
    {
        HideUI();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transitionToNextScene.TurnOnLevel();
    }

    public void FinishGameAndExitInMenu()
    {
        PlayerPrefs.SetInt("EndGame", 1);
        transitionToNextScene.EndGame();
    }

    public void HideUI()
    {
        _skipPhraseButton.SetActive(false);
        _dots.SetActive(false);
    }

    public void TurnOnFirstLevel()
    {
        transitionToNextScene.TurnOnLevel();
    }
}
