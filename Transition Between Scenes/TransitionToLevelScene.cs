using System.Collections;
using UnityEngine;

public class TransitionToLevelScene : TransitionToNextScene
{
    [SerializeField] private Animator _whiteFadeAnimator;

    protected override void outBlackFade()
    {
        _blackFadeAnimator.Play("blackFadeOut");
        StartCoroutine(outWhiteFadeDelay());
    }

    private IEnumerator outWhiteFadeDelay()
    {
        yield return new WaitForSeconds(1.6f);
        _whiteFadeAnimator.Play("whiteFadeOut");
    }

    protected override void inWhiteFade() 
    {
        _whiteFadeAnimator.Play("whiteFadeIn");
    }
}
