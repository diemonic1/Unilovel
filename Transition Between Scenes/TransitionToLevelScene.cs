using System.Collections;
using UnityEngine;

public class TransitionToLevelScene : TransitionToNextScene
{
    [SerializeField] private Animator _whiteFadeAnimator;

    protected override void StartAnotherFadeAnimations()
    {
        _whiteFadeAnimator.Play("whiteFadeOut");
    }

    protected override void InWhiteFade()
    {
        _whiteFadeAnimator.Play("whiteFadeIn");
    }
}
