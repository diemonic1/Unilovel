using System.Collections;
using UnityEngine;

public class TransitionToNextScene : MonoBehaviour
{
    public bool IsTransitionNow { get; protected set; }

    [SerializeField] protected Animator _blackFadeAnimator;

    [Header("Links to instances")]
    [SerializeField] private AudioVolumeController audioVolumeController;

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    protected virtual IEnumerator StartDelay()
    {
        outBlackFade();
        IsTransitionNow = true;
        yield return new WaitForSeconds(2.3f);
        IsTransitionNow = false;
    }

    protected virtual void outBlackFade()
    {
        _blackFadeAnimator.Play("blackFadeOut");
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("EndGame", 0);
        PlayerPrefs.SetInt("lvl", 0);
        PlayerPrefs.SetInt("progress", 0);
        PlayerPrefs.SetInt("dial", 0);

        PlayerPrefs.SetString("nameOfNextScene", "none");

        playAnim_volumeDown();
    }

    public void continueGame()
    {
        if (PlayerPrefs.GetInt("progress") % 2 == 0)
            PlayerPrefs.SetString("nameOfNextScene", "Dialogue");
        else
            PlayerPrefs.SetString("nameOfNextScene", "level");

        playAnim_volumeDown();
    }

    public void exitInMenu()
    {
        PlayerPrefs.SetString("nameOfNextScene", "MainMenu");

        playAnim_volumeDown();
    }

    public void restartLevel()
    {
        PlayerPrefs.SetString("nameOfNextScene", "level");

        playAnim_volumeDown();
    }

    public void turnOnLevel()
    {
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
        PlayerPrefs.SetInt("progress", PlayerPrefs.GetInt("progress") + 1);

        PlayerPrefs.SetString("nameOfNextScene", "level");

        playAnim_volumeDown();
    }

    public void turnOnDialogue()
    {
        PlayerPrefs.SetInt("dial", PlayerPrefs.GetInt("lvl"));
        PlayerPrefs.SetInt("progress", PlayerPrefs.GetInt("progress") + 1);

        PlayerPrefs.SetString("nameOfNextScene", "Dialogue");

        StartCoroutine(turnOnDialogueDelay());
    }

    private IEnumerator turnOnDialogueDelay()
    {
        yield return new WaitForSeconds(0.5f);
        inWhiteFade();

        yield return new WaitForSeconds(1.6f);
        playAnim_volumeDown();
    }

    public void endGame()
    {
        PlayerPrefs.SetInt("EndComics", 1);
        PlayerPrefs.SetString("nameOfNextScene", "MainMenu");

        playAnim_volumeDown();
    }

    public void exitFromGame()
    {
        PlayerPrefs.SetString("nameOfNextScene", "exitGame");

        playAnim_volumeDown();
    }

    private void playAnim_volumeDown()
    {
        IsTransitionNow = true;

        audioVolumeController.startFadingVolume();
        _blackFadeAnimator.Play("blackFadeIn");
    }

    protected virtual void inWhiteFade() { }

    // On a separate scene "loader" is the loading animation and the script "loaderScript". 
    // With "numActionLoader" it determines which scene to load.
    public void startTransitionOnNextScene()
    {
        switch (PlayerPrefs.GetString("nameOfNextScene"))
        {
            case "none":
                Application.LoadLevel("Dialogue");
                break;
            case "exitGame":
                Application.Quit();
                break;
            default:
                Application.LoadLevel("loader");
                break;
        }
    }
}