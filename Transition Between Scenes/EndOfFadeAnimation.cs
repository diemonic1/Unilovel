using UnityEngine;

public class EndOfFadeAnimation : MonoBehaviour
{
    [Header("Links to instances")]
    [SerializeField] private TransitionToNextScene transitionToNextScene;

    public void AnimationEvent_endOfFadeAnimation()
    {
        transitionToNextScene.StartTransitionOnNextScene();
    }
}
