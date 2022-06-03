using UnityEngine;

public class DialogueAdditionalActions : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private GameObject _skipPhraseButton, _dots;

    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;

    public void playJumpAnimation()
    {
        _characterAnimator.Play("jump");
    }

    public void turnOnLevelScene()
    {
        hideUI();
        Screen.lockCursor = true;
        transitionToNextScene.turnOnLevel();
    }

    public void finishGameAndExitInMenu()
    {
        PlayerPrefs.SetInt("EndGame", 1);
        transitionToNextScene.endGame();
    }

    public void hideUI()
    {
        _skipPhraseButton.SetActive(false);
        _dots.SetActive(false);
    }

    public void turnOnFirstLevel()
    {
        transitionToNextScene.turnOnLevel();
    }

}
