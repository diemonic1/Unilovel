using System.Collections;
using UnityEngine;

public class TransitionToLevelScene : TransitionToNextScene
{
    [SerializeField] private Animator _whiteFadeAnimator;

    protected override void OutBlackFade()
    {
        _blackFadeAnimator.Play("blackFadeOut");
        StartCoroutine(OutWhiteFadeDelay());
    }

    protected override void InWhiteFade()
    {
        _whiteFadeAnimator.Play("whiteFadeIn");
    }

    private IEnumerator OutWhiteFadeDelay()
    {
        yield return new WaitForSeconds(1.6f);
        _whiteFadeAnimator.Play("whiteFadeOut");
    }
}
