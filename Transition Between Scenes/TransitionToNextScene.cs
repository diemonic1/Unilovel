using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToNextScene : MonoBehaviour
{
    [SerializeField] protected Animator _blackFadeAnimator;

    [Header("Links to instances")]
    [SerializeField] private AudioVolumeController audioVolumeController;

    public bool IsTransitionNow { get; protected set; }

    // On a separate scene "loader" is the loading animation and the script "loaderScript".
    // With "numActionLoader" it determines which scene to load.
    public void StartTransitionOnNextScene()
    {
        switch (PlayerPrefs.GetString("nameOfNextScene"))
        {
            case "none":
                SceneManager.LoadScene("Dialogue");
                break;
            case "exitGame":
                Application.Quit();
                break;
            default:
                SceneManager.LoadScene("loader");
                break;
        }
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("EndGame", 0);
        PlayerPrefs.SetInt("lvl", 0);
        PlayerPrefs.SetInt("progress", 0);
        PlayerPrefs.SetInt("dial", 0);

        PlayerPrefs.SetString("nameOfNextScene", "none");

        PlayAnim_volumeDown();
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("progress") % 2 == 0)
            PlayerPrefs.SetString("nameOfNextScene", "Dialogue");
        else
            PlayerPrefs.SetString("nameOfNextScene", "level");

        PlayAnim_volumeDown();
    }

    public void ExitInMenu()
    {
        PlayerPrefs.SetString("nameOfNextScene", "MainMenu");

        PlayAnim_volumeDown();
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetString("nameOfNextScene", "level");

        PlayAnim_volumeDown();
    }

    public void TurnOnLevel()
    {
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
        PlayerPrefs.SetInt("progress", PlayerPrefs.GetInt("progress") + 1);

        PlayerPrefs.SetString("nameOfNextScene", "level");

        PlayAnim_volumeDown();
    }

    public void TurnOnDialogue()
    {
        PlayerPrefs.SetInt("dial", PlayerPrefs.GetInt("lvl"));
        PlayerPrefs.SetInt("progress", PlayerPrefs.GetInt("progress") + 1);

        PlayerPrefs.SetString("nameOfNextScene", "Dialogue");

        StartCoroutine(TurnOnDialogueDelay());
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("EndComics", 1);
        PlayerPrefs.SetString("nameOfNextScene", "MainMenu");

        PlayAnim_volumeDown();
    }

    public void ExitFromGame()
    {
        PlayerPrefs.SetString("nameOfNextScene", "exitGame");

        PlayAnim_volumeDown();
    }

    protected virtual IEnumerator StartDelay()
    {
        OutBlackFade();
        IsTransitionNow = true;
        yield return new WaitForSeconds(2.3f);
        IsTransitionNow = false;
    }

    protected virtual void OutBlackFade()
    {
        _blackFadeAnimator.Play("blackFadeOut");
    }

    protected virtual void InWhiteFade()
    {
    }

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator TurnOnDialogueDelay()
    {
        yield return new WaitForSeconds(0.5f);
        InWhiteFade();

        yield return new WaitForSeconds(1.6f);
        PlayAnim_volumeDown();
    }

    private void PlayAnim_volumeDown()
    {
        IsTransitionNow = true;

        audioVolumeController.StartFadingVolume();
        _blackFadeAnimator.Play("blackFadeIn");
    }
}